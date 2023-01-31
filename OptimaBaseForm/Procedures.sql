IF NOT EXISTS 
(
	SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'ELTES' 
)
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA ELTES';
END

--MAPPING wysyłki i atrybutów
CREATE TABLE [ELTES].[OptDetalMapping](
[Map_Id] [int] IDENTITY(1,1) NOT NULL,
[Map_OptId] [int] NOT NULL,
[Map_OptValue] varchar(100) NOT NULL,
[Map_ItemId] [int] NOT NULL,
[Map_ItemValue] varchar(100) NOT NULL,
[Map_AddItemId] [int] NOT NULL,
[Map_AddItemValue] varchar(100) NOT NULL,
[Map_Typ] [int] NOT NULL)
GO

CREATE TABLE [ELTES].[OptDetalSpecialPrice](
[Sp_Id] [int] primary Key IDENTITY(1,1) NOT NULL,
[Sp_Name] varchar(100) NOT NULL,
[Sp_TwrOptId] [int] NOT NULL,
[Sp_TwrCode] varchar(100) NOT NULL,
[Sp_TwcPriceNumber] [int] NOT NULL,
[Sp_OldPrice] DECIMAL(10,2) NOT NULL,
[Sp_SpecialPrice] DECIMAL(10,2) NOT NULL,
[Sp_DateFrom] DATETIME NOT NULL,
[Sp_DateTo] DATETIME NOT NULL
)
GO



--StringSplitter

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[OptDetalGetMapping]'))
DROP PROCEDURE [ELTES].[OptDetalGetMapping]  
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[OptDetalGetPricesFromOPT]'))
DROP PROCEDURE [ELTES].[OptDetalGetPricesFromOPT]  
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetProductsByCode]'))
DROP PROCEDURE [ELTES].[GetProductsByCode] 
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetSpecialPricesByName]'))
DROP PROCEDURE [ELTES].[GetSpecialPricesByName] 
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[DeleteSpFromTable]'))
DROP PROCEDURE [ELTES].[DeleteSpFromTable] 
GO

CREATE PROCEDURE [ELTES].[OptDetalGetMapping] @type int
AS
SELECT Map_Id,Map_OptId,Map_OptValue,Map_ItemId,Map_ItemValue,Map_AddItemId, Map_AddItemValue
FROM ELTES.OptDetalMapping
WHERE Map_Typ=@type
GO

CREATE PROCEDURE [ELTES].[OptDetalGetPricesFromOPT]
AS  
SELECT DfC_Lp, DfC_Nazwa FROM CDN.DefCeny
UNION ALL
SELECT TOP(1) 0,'brak'  FROM CDN.DefCeny
ORDER BY DfC_Lp
GO

  CREATE PROCEDURE [ELTES].[GetProductsByCode] @prod_Code varchar(20), @priceNr int
  AS
  SELECT Twr_TwrId, 
  ISNULL(Twr_EAN, 0) AS Ean,
  ISNULL(Twr_Kod, 0) AS Sku,
  TwC_Wartosc
  FROM CDN.Towary
  JOIN CDN.TwrCeny ON Twr_TwrId = TwC_TwrID AND TwC_TwCNumer = @priceNr
  WHERE Twr_EAN = @prod_Code OR Twr_Kod = @prod_Code
  GO

 CREATE PROCEDURE [ELTES].[AddSpecialPriceProduct] @prodCode varchar(20), @priceNr int, @prodId int, @oldPrice decimal,@salePrice decimal, @name varchar(100), @dateFrom datetime, @dateTo datetime
AS
INSERT INTO [ELTES].[OptDetalSpecialPrice] (Sp_Name, Sp_TwrOptId,Sp_TwrCode,Sp_TwcPriceNumber,Sp_OldPrice,Sp_SpecialPrice,Sp_DateFrom,Sp_DateTo) 
VALUES (@name, @prodId, @prodCode, @priceNr, @oldPrice, @salePrice, @dateFrom, @dateTo )
GO

    CREATE PROCEDURE [ELTES].[UpdatePrice] @idProduct int, @price decimal(10,2), @priceNr int
  AS
  UPDATE [CDN].[TwrCeny]
set TwC_Wartosc = @price
where TwC_TwrID = @idProduct AND TwC_TwCNumer = @priceNr
GO
  CREATE PROCEDURE [ELTES].[GetSpecialPricesByName] @spName varchar(100)
  AS
  SELECT Sp_Name,Sp_TwrOptId,Sp_TwrCode,Sp_TwcPriceNumber,Sp_OldPrice,Sp_SpecialPrice,Sp_DateFrom,Sp_DateTo  FROM [ELTES].[OptDetalSpecialPrice]
  WHERE Sp_Name = @spName
  GO

    CREATE PROCEDURE [ELTES].[DeleteSpFromTable] @name varchar(100), @prodId int, @priceNr int
  AS
  DELETE FROM [ELTES].[OptDetalSpecialPrice] 
  WHERE Sp_Name = @name AND Sp_TwcPriceNumber = @priceNr AND Sp_TwrOptId = @prodId
  GO

  CREATE PROCEDURE [ELTES].[GetOptProductAttributes]
AS
SELECT DeA_DeAId, DeA_Kod
FROM  CDN.DefAtrybuty
WHERE DeA_Typ = 1
GO