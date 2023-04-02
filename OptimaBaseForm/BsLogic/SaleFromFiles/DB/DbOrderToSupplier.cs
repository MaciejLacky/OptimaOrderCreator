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
    public class DbOrderToSupplier
    {
        public static DataTable GetLastKntToSupplierOrder(int twrId)
        {
            DataTable dtProducts = new DataTable();
            using (SqlConnection con = new SqlConnection(Settings.Default.SqlConnectionString))
            {
                try
                {
                    SqlDataAdapter dtAdapter = new SqlDataAdapter($"EXEC [ELTES].[GetLastKntSupplierOptPlus]{twrId}", con);
                    dtAdapter.Fill(dtProducts);
                }
                catch (Exception ex)
                {
                    Log.Error("DbOrderToSupplier " + "GetLastKntToSupplierOrder " + ex.Message);
                }
                
            }
            return dtProducts;
        }
    }
}
