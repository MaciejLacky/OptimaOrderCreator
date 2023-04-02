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
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetGroupsFromOPTPlus]'))
DROP PROCEDURE [ELTES].[GetGroupsFromOPTPlus] 
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetOptPlusProductAttributes]'))
DROP PROCEDURE [ELTES].[GetOptPlusProductAttributes]
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetOptPlusMag]'))
DROP PROCEDURE [ELTES].[GetOptPlusMag]
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetKntSupplierOptPlus]'))
DROP PROCEDURE [ELTES].[GetKntSupplierOptPlus]
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetLastKntSupplierOptPlus]'))
DROP PROCEDURE [ELTES].[GetLastKntSupplierOptPlus]
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[ELTES].[GetProductSaleByProductNameOptPlus]'))
DROP PROCEDURE [ELTES].[GetProductSaleByProductNameOptPlus]
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

  CREATE PROCEDURE [ELTES].[GetOptPlusProductAttributes]
AS
SELECT DeA_DeAId, DeA_Kod
FROM  CDN.DefAtrybuty
WHERE DeA_Typ = 1
GO

CREATE PROCEDURE [ELTES].[GetGroupsFromOPTPlus]
AS  
SELECT TwG_TwGID, TwG_GIDNumer, TwG_Kod, TwG_Nazwa, TwG_GIDNumer FROM CDN.TwrGrupy
WHERE TwG_GIDTyp = -16
GO

CREATE PROCEDURE [ELTES].[GetOptPlusMag]
AS  
SELECT Mag_MagId, Mag_Nazwa FROM CDN.Magazyny
GO

CREATE PROCEDURE [ELTES].[GetKntSupplierOptPlus]
AS  
SELECT Knt_KntId, 
ISNULL( Knt_Kod,'') AS Knt_Kod,
ISNULL(Knt_Nazwa1,'') AS Knt_Nazwa1 
FROM CDN.Kontrahenci
WHERE Knt_Rodzaj_Dostawca = 1
GO

CREATE PROCEDURE [ELTES].[GetProductSaleByProductNameOptPlus] @productName varchar(max), @daysBack integer, @twrAtrId integer, @twrAtrTxt varchar(max), @magId integer
AS
SELECT Twr_TwrId, Twr_Kod, 
ISNULL(Twr_IloscMin,0) AS Twr_IloscMin, 
ISNULL(Twr_IloscMax,0) AS Twr_IloscMax, 
ISNULL(Twr_IloscZam,0) AS Twr_IloscZam, 
ISNULL(TwI_Ilosc,0) AS TwI_Ilosc,  
ISNULL(Sum(TrE_WartoscNetto),0) AS Wartosc_Spr, 
ISNULL(SUM(TrE_Ilosc),0) AS Ilosc_Spr 
FROM
CDN.TraElem
JOIN CDN.TraNag ON TrE_TrNId = TrN_TrNID
JOIN CDN.Towary ON TrE_TwrId = Twr_TwrId
JOIN CDN.TwrAtrybuty ON TwA_TwrId = Twr_TwrId
LEFT OUTER JOIN CDN.TwrIlosci Ilosci ON Ilosci.TwI_TwIId =(SELECT TOP 1 IL.TwI_TwIId From CDN.TwrIlosci IL Where IL.TwI_TwrId = Twr_TwrID And IL.TwI_MagId =  @magId And IL.TwI_Data <= Convert(DATETIME,GETDATE(),120) ORDER BY IL.TwI_Data DESC) 
WHERE TrE_TypDokumentu IN (302,305)
AND TrN_Anulowany = 0
AND TrE_TwrTyp = 1
AND TrE_TwrNazwa LIKE @productName +'%' 
AND TwA_DeAId = @twrAtrId
AND TwA_WartoscTxt =  @twrAtrTxt
AND TrE_DataDok > DATEADD(DAY, -@daysBack, GETDATE())
GROUP BY Twr_TwrId, Twr_Kod, Twr_IloscMin, Twr_IloscMax, Twr_IloscZam, TwI_Ilosc
GO

CREATE PROCEDURE [ELTES].[GetLastKntSupplierOptPlus] @twr_twrId integer
AS  
SELECT TOP 1 Knt_KntId, Knt_Kod, Knt_Nazwa1, TrN_NumerPelny, TrN_TS_Zal
FROM CDN.Kontrahenci
JOIN CDN.TraNag ON TrN_PodID = Knt_KntId
JOIN CDN.TraElem ON TrE_TrNId = TrN_TrNID
WHERE TrN_TypDokumentu = 301
AND TrN_Anulowany = 0
AND TrE_TwrId = @twr_twrId
ORDER BY TrN_TS_Zal DESC
GO