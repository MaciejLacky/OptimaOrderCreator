using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm
{
    public class Log
    {
        public static event Action<string> OnChange;
        public static void TextBox(string text) => OnChange.Invoke(text);

        public static void Error(string log)
        {
            try
            {
                if (Settings.Default.LogPath == "") return;
                using (var sw = new StreamWriter($"{Settings.Default.LogPath}\\{DateTime.Now.Date:yyyy-MM-dd}_Log.txt", true)) sw.WriteLine($"{DateTime.Now} {log}\r\n");
            }
            catch { }
        }

        public static void Info(string log)
        {
            try
            {
                if (Settings.Default.LogPath == "") return;
                using (var sw = new StreamWriter($"{Settings.Default.LogPath}\\{DateTime.Now.Date:yyyy-MM-dd}_Log.txt", true)) sw.WriteLine($"{DateTime.Now} {log}\r\n");
            }
            catch { }
        }

        public static void Info2(string log)
        {
            try
            {
                if (Settings.Default.LogPath == "") return;
                using (var sw = new StreamWriter($"{Settings.Default.LogPath}\\{DateTime.Now.Date:yyyy-MM-dd}_LogImport.txt", true)) sw.WriteLine($"{DateTime.Now} {log}\r\n");
            }
            catch { }
        }

        public static void DeleteOldLogs(int days)
        {
            int day = 0;
            do
            {
                string path = $"{Settings.Default.LogPath}\\{DateTime.Now.Date.AddDays(-(days + day)):yyyy-MM-dd}_Log.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Info($"Usunięto plik logów {path} starszy niż {days} dni");
                }
                day++;
            }
            while (File.Exists($"{Settings.Default.LogPath}\\{DateTime.Now.Date.AddDays(-(days + day)):yyyy-MM-dd}_Log.txt"));
        }
    }
}
