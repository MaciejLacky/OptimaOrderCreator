using CDNBase;
using Microsoft.VisualBasic.Logging;
using OptimaBaseForm.Db;
using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application = CDNBase.Application;

namespace OptimaBaseForm.Optima
{
    public class Opt
    {
        protected static IApplication Application = null;
        protected static IApplication ApplicationFirma2 = null;
        public static ILogin Login = null;
        public static ILogin LoginFirma2 = null;
        //private static ILog Log = LogManager.GetLogger("mylog");

        public static bool LogIn(bool firma2 = false)
        {
            Logout();
            CDNBase.AdoSession optSesja = null;
            return LogIn(ref optSesja, firma2);
        }

        public static bool LogInFirma2()
        {
            LogoutFirma2();
            CDNBase.AdoSession optSesja2 = null;
            return LogInFirma2(ref optSesja2);
        }

        public static string LogInTest(ref string log, bool firma2 = false)
        {
            string currentDirectory = "";
            string sqlConnString = "";
            string verOfDLLBaselinkerSync = "";
            string verOfOptima = "";

            try
            {
                currentDirectory = Environment.CurrentDirectory;
                CDNBase.AdoSession optSesja = null;


                if (!LogIn(ref optSesja, firma2))
                {
                    log = "Błąd logowania do Optimy. Sprawdź plik log";
                    return "";
                }
                if (firma2)
                {
                    log = "SUKCES!!!";
                    return "";
                }
                optSesja = Login.CreateSession();
                string[] tblConString = optSesja.Connection.ConnectionString.Split(';');
                try //Jeżeżli Login zintegrowany z NT
                {
                    sqlConnString = tblConString[3].Substring(tblConString[3].IndexOf("Server")) + ";" + tblConString[4] + ";" + tblConString[2] + ";" +
                                tblConString[5].Remove(tblConString[5].Length - 1);
                }
                catch //Jeżeżli Login NIE zintegrowany z NT
                {
                    sqlConnString = tblConString[1] + ";" + tblConString[3] + ";" + tblConString[4].Substring(tblConString[4].IndexOf("Server")) + ";" + tblConString[5];
                }

            }
            catch (Exception ex)
            {
                log = "Błąd logowania do Optimy " + ex.Message;
            }
            finally
            {
                Environment.CurrentDirectory = currentDirectory;
                Logout();
            }
            Settings.Default.SqlConnectionString = sqlConnString;
            Settings.Default.Save();
            Settings.Default.Reload();
            var versions = CheckCompabilityVersion();
            if (versions.Count > 1)
            {
                verOfDLLBaselinkerSync = versions[0];
                verOfOptima = versions[1];
            }
            log = $"Test połączenia z Optimą OK \n\nver. BaseLinkerSync : {verOfDLLBaselinkerSync} \nver. ComarchOptima : {verOfOptima}";

            return sqlConnString;
        }
        public static string LogInTestUser()
        {
            string currentDirectory = "";
            string sqlConnString = "";
            try
            {
                currentDirectory = Environment.CurrentDirectory;
                CDNBase.AdoSession optSesja = null;



                optSesja = Login.CreateSession();
                string[] tblConString = optSesja.Connection.ConnectionString.Split(';');
                try //Jeżeżli Login zintegrowany z NT
                {
                    sqlConnString = tblConString[3].Substring(tblConString[3].IndexOf("Server")) + ";" + tblConString[4] + ";" + tblConString[2] + ";" +
                                tblConString[5].Remove(tblConString[5].Length - 1);
                }
                catch //Jeżeżli Login NIE zintegrowany z NT
                {
                    sqlConnString = tblConString[1] + ";" + tblConString[3] + ";" + tblConString[4].Substring(tblConString[4].IndexOf("Server")) + ";" + tblConString[5];
                }

            }
            catch (Exception ex)
            {
                Log.Error("Błąd logowania do Optimy przy zmianie operatora z mapowania " + ex.Message);
            }
            finally
            {
                Environment.CurrentDirectory = currentDirectory;
                Logout();
            }
            Settings.Default.SqlConnectionString = sqlConnString;
            Settings.Default.Save();
            Settings.Default.Reload();

            return sqlConnString;
        }

        public static string LogInTestFirma2(ref string log)
        {
            string currentDirectory = "";
            string sqlConnString = "";
            string verOfDLLBaselinkerSync = "";
            string verOfOptima = "";

            try
            {
                currentDirectory = Environment.CurrentDirectory;
                CDNBase.AdoSession optSesja2 = null;

                if (!LogInFirma2(ref optSesja2))
                {
                    log = "Błąd logowania do Optimy. Sprawdź plik log";
                    return "";
                }

                optSesja2 = LoginFirma2.CreateSession();
                string[] tblConString = optSesja2.Connection.ConnectionString.Split(';');
                try //Jeżeżli Login zintegrowany z NT
                {
                    sqlConnString = tblConString[3].Substring(tblConString[3].IndexOf("Server")) + ";" + tblConString[4] + ";" + tblConString[2] + ";" +
                                tblConString[5].Remove(tblConString[5].Length - 1);
                }
                catch //Jeżeżli Login NIE zintegrowany z NT
                {
                    sqlConnString = tblConString[1] + ";" + tblConString[3] + ";" + tblConString[4].Substring(tblConString[4].IndexOf("Server")) + ";" + tblConString[5];
                }

            }
            catch (Exception ex)
            {
                log = "Błąd logowania do Optimy " + ex.Message;
            }
            finally
            {
                Environment.CurrentDirectory = currentDirectory;
                LogoutFirma2();
            }
            Settings.Default.SqlConnectionStringFirma2 = sqlConnString;
            Settings.Default.Save();
            Settings.Default.Reload();
            var versions = CheckCompabilityVersion();
            if (versions.Count > 1)
            {
                verOfDLLBaselinkerSync = versions[0];
                verOfOptima = versions[1];
            }
            log = $"Test połączenia z Optimą OK \n\nver. BaseLinkerSync : {verOfDLLBaselinkerSync} \nver. Comarch Optima : {verOfOptima}";

            return sqlConnString;
        }

        private static bool LogIn(ref AdoSession optSesja, bool firma2)
        {
            bool ok = true;
            try
            {
                object[] hPar = new object[] { 0, 0, 0, 0, 0, Settings.Default.OptHAP ? 0 : 1, 0, 0, 0, 0, 0, 0, 0, 0, Settings.Default.OptKBP ? 0 : 1, Settings.Default.OptKBP ? 1 : 0, Settings.Default.OptHAP ? 1 : 0, 0 };
                Environment.CurrentDirectory = @Settings.Default.OptPath;

                Application = new Application();
                DateTime dt = DateTime.Now;
                Application.AppToday = dt.ToOADate();

                if (Settings.Default.SqlOptBazaKonfigConnectionStr != "")
                    Application.KonfigConnectStr = Settings.Default.SqlOptBazaKonfigConnectionStr;
                if (firma2) Application.KonfigConnectStr = Settings.Default.Opt2KonfigConnectStr;

                Login = Application.LockApp(256, 5000, null, null, null, null);
                if (firma2)
                {
                    if (Settings.Default.OptModulyUsera)
                        Login = Application.Login(Settings.Default.Opt2Operator, Settings.Default.Opt2Haslo, Settings.Default.Opt2Firma);
                    else
                        Login = Application.Login(Settings.Default.Opt2Operator, Settings.Default.Opt2Haslo, Settings.Default.Opt2Firma, hPar[0], hPar[1], hPar[2], hPar[3], hPar[4], hPar[5], hPar[6], hPar[7], hPar[8], hPar[9], hPar[10], hPar[11], hPar[12], hPar[13], hPar[14], hPar[15], hPar[16], hPar[17]);
                }
                else
                {
                    if (Settings.Default.OptModulyUsera)
                        Login = Application.Login(Settings.Default.OptUser, Settings.Default.OptPassword.Decrypt(), Settings.Default.OptCompany);
                    else
                        Login = Application.Login(Settings.Default.OptUser, Settings.Default.OptPassword.Decrypt(), Settings.Default.OptCompany, hPar[0], hPar[1], hPar[2], hPar[3], hPar[4], hPar[5], hPar[6], hPar[7], hPar[8], hPar[9], hPar[10], hPar[11], hPar[12], hPar[13], hPar[14], hPar[15], hPar[16], hPar[17]);
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Log.Error("Logowanie " + ex.Message);
            }
            return ok;
        }

        private static bool LogInFirma2(ref AdoSession optSesja)
        {
            bool ok = true;
            try
            {
                object[] hPar = new object[] { 0, 0, 0, 0, 0, Settings.Default.OptHAP ? 0 : 1, 0, 0, 0, 0, 0, 0, 0, 0, Settings.Default.OptKBPFirma2 ? 0 : 1, Settings.Default.OptKBPFirma2 ? 1 : 0, Settings.Default.OptHAPFirma2 ? 1 : 0, 0 };
                Environment.CurrentDirectory = @Settings.Default.OptPathFirma2;

                ApplicationFirma2 = new Application();
                DateTime dt = DateTime.Now;
                ApplicationFirma2.AppToday = dt.ToOADate();

                if (Settings.Default.SqlOptBazaKonfigConnectionStrFirma2 != "")
                    ApplicationFirma2.KonfigConnectStr = Settings.Default.SqlOptBazaKonfigConnectionStrFirma2;

                LoginFirma2 = ApplicationFirma2.LockApp(256, 5000, null, null, null, null);
                if (Settings.Default.OptModulyUseraFirma2)
                    LoginFirma2 = ApplicationFirma2.Login(Settings.Default.OptUserFirma2, Settings.Default.OptPasswordFirma2, Settings.Default.OptCompanyFirma2);
                else
                    LoginFirma2 = ApplicationFirma2.Login(Settings.Default.OptUserFirma2, Settings.Default.OptPasswordFirma2, Settings.Default.OptCompanyFirma2, hPar[0], hPar[1], hPar[2], hPar[3], hPar[4], hPar[5], hPar[6], hPar[7], hPar[8], hPar[9], hPar[10], hPar[11], hPar[12], hPar[13], hPar[14], hPar[15], hPar[16], hPar[17]);
            }
            catch (Exception ex)
            {
                ok = false;
                Log.Error("Logowanie " + ex.Message);
            }
            return ok;
        }

        public static void Logout()
        {
            try
            {
                Login = null;
                Application.UnlockApp();
                Application = null;
            }
            catch (Exception)
            {
            }
        }

        public static void LogoutFirma2()
        {
            try
            {
                LoginFirma2 = null;
                ApplicationFirma2.UnlockApp();
                ApplicationFirma2 = null;
            }
            catch (Exception)
            {
            }
        }

        public static string GetprogramDllVersion()
        {
            string verOfDLLBaselinkerSync = "";

            try
            {
                var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                if (assemblies.Length > 0)
                {
                    foreach (var item in assemblies)
                    {
                        if (item.Name == "Common.Logic")
                        {
                            verOfDLLBaselinkerSync = item.Version.ToString().Trim('{').Trim('}');
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                verOfDLLBaselinkerSync = "Bład pobrania wersji: " + ex.Message;
            }

            return verOfDLLBaselinkerSync;
        }

        public static void SetProperty(object o, string Name, object Value)
        {
            if (o == null)
                return;
            o.GetType().InvokeMember(Name, BindingFlags.SetProperty, null, o, new object[] { Value });
        }

        public static bool IsFreeLicense()
        {
            AdoSession sesja = Opt.Login.CreateSession();
            try
            {
                sesja.Save();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    Opt.Logout();
                }
                catch { }
                Log.Error("Opt, IsFreeLicense, Brak licencji: " + ex.Message);
                return false;
            }
        }

        public static bool IsFreeLicenseFirma2()
        {
            AdoSession sesja = Opt.LoginFirma2.CreateSession();
            try
            {
                sesja.Save();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    Opt.Logout();
                }
                catch { }
                Log.Error("Opt, IsFreeLicense, Brak licencji: " + ex.Message);
                return false;
            }
        }

        public static List<string> CheckCompabilityVersion()
        {

            List<string> versions = new List<string>();
            if (Settings.Default.SqlConnectionString == "") return versions;
            string verDLL = "";
            string verOpt = "";
            var versionDll = GetprogramDllVersion().Split('.');
            var versionOptima = DbOptimaInfoConfig.Get(3).Split('.');
            if (versionDll.Length > 1)
            {
                verDLL += versionDll[0] + ".";
                verDLL += versionDll[1].Replace("0", "") == "" ? "0" : versionDll[1].Replace("0", "");
                versions.Add(verDLL);
            }
            if (versionOptima.Length > 1)
            {
                verOpt += versionOptima[0] + ".";
                verOpt += versionOptima[1].Replace("0", "") == "" ? "0" : versionOptima[1].Replace("0", "");
                versions.Add(verOpt);
            }

            return versions;
        }

        //public static string VersionLabel
        //{
        //    get
        //    {
        //        if (System.Application.ApplicationDeployment.IsNetworkDeployed)
        //        {
        //            Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
        //            return string.Format("{0}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
        //        }
        //        else
        //        {
        //            var ver = Assembly.GetEntryAssembly().GetName().Version;
        //            return string.Format("{0}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
        //        }
        //    }
        //}
    }
}
