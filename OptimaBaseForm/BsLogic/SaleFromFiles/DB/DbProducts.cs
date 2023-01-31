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
    internal class DbProducts
    {
        public static DataTable GetByCode(string productCode, int priceNr)
        {
            DataTable dtProdOptima = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                "[ELTES].[GetProductsByCode]", Settings.Default.SqlConnectionString);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@prod_Code", productCode);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@priceNr", priceNr);
                sqlDataAdapter.Fill(dtProdOptima);
            }
            catch (Exception ex)
            {
                Log.Error("DbProducts " + "GetByCode " + ex.Message);
            }
            return dtProdOptima;
        }
    }
}
