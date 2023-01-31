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

        public static Dictionary<int, string> GetAtrValueToUpdPricesFromOPT()
        {
            var dicPrices = new Dictionary<int, string>();
            DataTable dtPrices = new DataTable();
            try
            {
                string cmd = "[ELTES].[GetOptProductAttributes]";
                new SqlDataAdapter($"EXEC {cmd}", Settings.Default.SqlConnectionString).Fill(dtPrices);
            }
            catch (Exception ex)
            {
                Log.Error("Config" + "Błąd podczas pobierania cen z Optimy: " + ex.Message);
            }

            foreach (DataRow row in dtPrices.Rows) dicPrices.Add(Convert.ToInt32(row["DeA_DeAId"]), row["DeA_Kod"].ToString());

            return dicPrices;
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
