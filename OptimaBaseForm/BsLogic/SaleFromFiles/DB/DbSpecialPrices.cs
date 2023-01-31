using OptimaBaseForm.BsLogic.SaleFromFiles.Dto;
using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.BsLogic.SaleFromFiles.DB
{
    internal class DbSpecialPrices
    {
        public static void AddToSpecialPriceTable(List<DtoSpecialPrice> products)
        {
            int counter = 0;
            foreach (var item in products)
            {
                SqlConnection con = new SqlConnection(Settings.Default.SqlConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("[ELTES].[AddSpecialPriceProduct]", con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@prodCode", item.codeItem);
                    sqlCommand.Parameters.AddWithValue("@priceNr", item.typePrice);
                    sqlCommand.Parameters.AddWithValue("@prodId", item.IdItem);
                    sqlCommand.Parameters.AddWithValue("@oldPrice", item.oldPriceBrutto);
                    sqlCommand.Parameters.AddWithValue("@salePrice", item.salePriceBrutto);
                    sqlCommand.Parameters.AddWithValue("@name", item.specialPriceName);
                    sqlCommand.Parameters.AddWithValue("@dateFrom", item.saleFrom);
                    sqlCommand.Parameters.AddWithValue("@dateTo", item.saleTo);
                    try
                    {
                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();

                        sqlCommand.ExecuteNonQuery();
                        con.Close();
                        counter++;                        
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"DbSpecialPrices.Add() produkt id {item.IdItem} " + ex.Message);
                    }
                }
            }
        }
        public static bool UpdatePrice(DtoSpecialPrice product, int type)
        {
            int counter = 0;
            SqlConnection con = new SqlConnection(Settings.Default.SqlConnectionString);
            using (SqlCommand sqlCommand = new SqlCommand("[ELTES].[UpdatePrice]", con))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@priceNr", product.typePrice);
                sqlCommand.Parameters.AddWithValue("@idProduct", product.IdItem);
                sqlCommand.Parameters.AddWithValue("@price", type == 1 ? product.salePriceBrutto : product.oldPriceBrutto);
                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    counter++;                    
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error($"DbSpecialPrices.UpgradePriced() produkt id {product.IdItem} " + ex.Message);
                    return false;
                }
            }
        }
        public static bool UpdateAtr(int twrId, int atrId, string atrValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.SqlConnectionString))
                {
                    conn.Open();                   
                    SqlCommand cmd = new SqlCommand($"UPDATE [CDN].[TwrAtrybuty] SET TwA_WartoscTxt = @atrValue WHERE TwA_TwrId = @twrId AND TwA_DeAId = @atrId" , conn);
                    cmd.Parameters.Add("@atrValue", SqlDbType.VarChar).Value = atrValue;
                    cmd.Parameters.Add("@atrId", SqlDbType.Int).Value = atrId;
                    cmd.Parameters.Add("@twrId", SqlDbType.Int).Value = twrId;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Log.Error($"aktualizacja atrybutu promocji {ex.Message}"); 
                return false;
            }
            
        }
        public static DataTable GetSpecialPricesByName(string name)
        {
            DataTable dtSpeciaPrices = new DataTable();
            string sqlProcedure = "[ELTES].[GetSpecialPricesByName]";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                sqlProcedure, Settings.Default.SqlConnectionString);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@spName", name);
            try
            {
                sqlDataAdapter.Fill(dtSpeciaPrices);
                return dtSpeciaPrices;
            }
            catch (Exception ex)
            {
                Log.Error("DbOrder.Get().Procedura: " + sqlProcedure + ": Nie udało się pobrać zamówień z bazy. Szczegóły: " + ex.Message);
                return dtSpeciaPrices;
            }
        }
        public static void DeleteSpecialPricesFromTable(string name, int prodId, int priceNr)
        {
            SqlConnection con = new SqlConnection(Settings.Default.SqlConnectionString);
            using (SqlCommand sqlCommand = new SqlCommand("[ELTES].[DeleteSpFromTable]", con))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@priceNr", priceNr);
                sqlCommand.Parameters.AddWithValue("@prodId", prodId);
                sqlCommand.Parameters.AddWithValue("@name", name);
                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Log.Error($"DbSpecialPrices.DeleteSpecialPricesFromTable() produkt id {prodId} " + ex.Message);
                }
            }
        }
    }
}
