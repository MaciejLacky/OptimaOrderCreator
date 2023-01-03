using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.Db
{
    internal class DbOptimaInfoConfig
    {
        public static string Get(int nrLine)
        {
            DataTable dtDoc = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                 @"SELECT  SYS_Wartosc   
                   FROM [CDN].[SystemCDN]
                   WHERE SYS_ID = " + nrLine,
                    Methods.GetSqlConnectionString());
                sqlDataAdapter.Fill(dtDoc);
                return dtDoc.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                string log = nrLine + " Problem z pobraniem wartości z GetOptimaInfoConfig " + ex.Message;
                Log.Info2(log);
                return log;
            }

        }
    }
}
