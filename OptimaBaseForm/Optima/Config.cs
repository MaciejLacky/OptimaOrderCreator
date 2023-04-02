using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Optima
{
    public enum MappingTypeDB
    {
        SpecialPrice = 1,
        UpdateProducts = 2,
    }
    public static class Config
    {
        public static Dictionary<int, string> GetPricesFromOPT()
        {
            var dicPrices = new Dictionary<int, string>();
            DataTable dtPrices = new DataTable();
            try
            {
                string cmd = "[ELTES].[OptDetalGetPricesFromOPT]";
                new SqlDataAdapter($"EXEC {cmd}", Settings.Default.SqlConnectionString).Fill(dtPrices);
            }
            catch (Exception ex)
            {
                Log.Error("Config" + "Błąd podczas pobierania cen z Optimy: " + ex.Message);
            }

            foreach (DataRow row in dtPrices.Rows) dicPrices.Add(Convert.ToInt32(row["DfC_Lp"]), row["DfC_Nazwa"].ToString());

            return dicPrices;
        }


        public static Dictionary<int, string> GetGroupsFromOPT()
        {
            DataTable dtMapping = new DataTable();
            Dictionary<int, string> listCatOpt = new Dictionary<int, string>();
            try
            {
                SqlDataAdapter dtAdapter = new SqlDataAdapter(
               "EXEC [ELTES].[GetGroupsFromOPTPlus]  "
               , Methods.GetSqlConnectionString());
                dtAdapter.Fill(dtMapping);
                foreach (DataRow item in dtMapping.Rows)
                {
                    listCatOpt.Add(Convert.ToInt32(item["TwG_GIDNumer"]), item["TwG_Nazwa"].ToString());
                }
            }
            catch (Exception ex) { Log.Error("OptGroups.GetGroupsFromOPTPlus " + ex.Message); }

            return listCatOpt.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<int, string> GetKntSupplier()
        {
            var dicPrices = new Dictionary<int, string>();
            DataTable dtPrices = new DataTable();
            try
            {
                string cmd = "[ELTES].[GetKntSupplierOptPlus]";
                new SqlDataAdapter($"EXEC {cmd}", Settings.Default.SqlConnectionString).Fill(dtPrices);
            }
            catch (Exception ex)
            {
                Log.Error("Config.GetKntSupplier" + "Błąd podczas pobierania knt z Optimy: " + ex.Message);
            }

            foreach (DataRow row in dtPrices.Rows) dicPrices.Add(Convert.ToInt32(row["Knt_KntId"]), row["Knt_Kod"].ToString());

            return dicPrices;
        }

        public static Dictionary<int, string> GetAtrProdValue()
        {
            var dicPrices = new Dictionary<int, string>();
            DataTable dtPrices = new DataTable();
            try
            {
                string cmd = "[ELTES].[GetOptPlusProductAttributes]";
                new SqlDataAdapter($"EXEC {cmd}", Settings.Default.SqlConnectionString).Fill(dtPrices);
            }
            catch (Exception ex)
            {
                Log.Error("Config.GetAtrProdValue()" + "Błąd podczas pobierania atr z Optimy: " + ex.Message);
            }

            foreach (DataRow row in dtPrices.Rows) dicPrices.Add(Convert.ToInt32(row["DeA_DeAId"]), row["DeA_Kod"].ToString());

            return dicPrices;
        }

        public static Dictionary<int, string> GetOptIdMag()
        {
            var dicOptStorages = new Dictionary<int, string>();

            DataTable mag = new DataTable();
            using (SqlConnection con = new SqlConnection(Settings.Default.SqlConnectionString))
            {
                try
                {
                    SqlDataAdapter dtAdapter = new SqlDataAdapter($"EXEC [ELTES].[GetOptPlusMag]", con);
                    dtAdapter.Fill(mag);
                }
                catch (Exception ex)
                {
                    Log.Error("Config.GetOptIdMag()" + "Błąd podczas pobierania mag z Optimy: " + ex.Message);
                }

            }

            foreach (DataRow row in mag.Rows)
                dicOptStorages.Add(Convert.ToInt32(row["Mag_MagId"]), row["Mag_Nazwa"].ToString());

            return dicOptStorages;
        }

        public static DataTable GetProductSaleByProductName(string productName, int daysBack, int twrAtrId, string twrAtrValue, int idMagOpt)
        {          
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[ELTES].[GetProductSaleByProductNameOptPlus]", Settings.Default.SqlConnectionString);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@magId", idMagOpt);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@productName", productName);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@daysBack", daysBack);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@twrAtrId", twrAtrId);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@twrAtrTxt", twrAtrValue);
                sqlDataAdapter.Fill(dt);                
            }
            catch (Exception ex)
            {
                Log.Error($"GetProductSaleByProductName: bład przy pobraniu sprzedaży za okres - {daysBack} dni " + ex.Message);
            }
            return dt;
        }

        public static void AddMaping(int mapOptId, string mapOptValue, int mapItemId, string mapItemValue, int mapAddItemId, string mapAddItemValue, MappingTypeDB mappingType)
        {
            try
            {
                string insert = "INSERT INTO [ELTES].[OptDetalMapping] (Map_OptId,Map_OptValue,Map_ItemId,Map_ItemValue,Map_AddItemId,Map_AddItemValue,Map_Typ) " +
                    "VALUES (@mapOptId, @mapOptValue, @mapItemId, @mapItemValue, @mapAddItemId, @mapAddItemValue, @mapType)";
                SqlConnection con = new SqlConnection(Methods.GetSqlConnectionString());
                using (SqlCommand command = new SqlCommand(insert, con))
                {
                    command.Parameters.Add("@mapOptId", SqlDbType.Int).Value = mapOptId;
                    command.Parameters.Add("@mapOptValue", SqlDbType.VarChar).Value = mapOptValue;
                    command.Parameters.Add("@mapItemId", SqlDbType.Int).Value = mapItemId;
                    command.Parameters.Add("@mapItemValue", SqlDbType.VarChar).Value = mapItemValue;
                    command.Parameters.Add("@mapAddItemId", SqlDbType.Int).Value = mapAddItemId;
                    command.Parameters.Add("@mapAddItemValue", SqlDbType.VarChar).Value = mapAddItemValue;
                    command.Parameters.Add("@mapType", SqlDbType.Int).Value = (int)mappingType;
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Config.AddMaping(): " + ex.Message);

            }
        }
        public static DataTable GetMapping(MappingTypeDB mappingType)
        {
            DataTable dtMapping = new DataTable();
            try
            {
                string command = "EXEC [ELTES].[OptDetalGetMapping] ";
                SqlDataAdapter dtAdapter = new SqlDataAdapter(command + (int)mappingType, Methods.GetSqlConnectionString());
                dtAdapter.Fill(dtMapping);
            }
            catch (Exception ex)
            {
                Log.Error("Config.GetMaping(): " + ex.Message);
            }
            return dtMapping;
        }
        public static string DeleteMaping(int atrMapId)
        {
            try
            {
                string insert = "DELETE [ELTES].[OptDetalMapping] WHERE Map_Id =@MapId";
                SqlConnection con = new SqlConnection(Methods.GetSqlConnectionString());
                using (SqlCommand command = new SqlCommand(insert, con))
                {
                    command.Parameters.Add("@MapId", SqlDbType.Int).Value = atrMapId;
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Config.DeleteMaping(): " + ex.Message);
            }
            return "";
        }
    }
}
