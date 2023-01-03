using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm
{
    public static class Methods
    {
        public static string Decrypt(this string cipherText)
        {
            try
            {
                string EncryptionKey = "ncr2190";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch { }
            return cipherText;
        }

        public static string GetSqlConnectionString(int connectStringType = 1)
        {
            if (Settings.Default.SqlConnStringPobierajZOpt) return connectStringType == 1 ? Settings.Default.SqlConnectionString : Settings.Default.SqlConnectionStringFirma2;
            if (Settings.Default.WindowsAuth) return $"Data Source={Settings.Default.SqlServerName};Initial Catalog={Settings.Default.SqlDatabaseName};Integrated Security=True";
            return $"Data Source={Settings.Default.SqlServerName};Initial Catalog={Settings.Default.SqlDatabaseName};User ID={Settings.Default.SqlLogin};Password={Settings.Default.SqlPassword}";
        }
    }
}
