using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.BsLogic.SaleFromFiles
{
    public class FileToRead
    {
        public static List<SpecialPriceModel> SpecialOfferFile(string filePath, string tbLog)
        {
            List<SpecialPriceModel> docList = new List<SpecialPriceModel>();
            string result = "";
            if (string.IsNullOrEmpty(filePath)) return docList;
            StreamReader? sr = null;
            try
            {
                sr = new StreamReader(filePath);
                using (sr)
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                    tbLog = "Wczytano plik poprawnie";
                }
            }
            catch (Exception ex)
            {
                Log.Error(" FileToRead.ReadFileToSettings() Problem z wczytaniem pliku" + ex.Message);
                tbLog = "Brak pliku do pobrania.";
            }

            result = result.Remove(0, 254); // na stałe  można dorobić w config 
            string[] rows = result.Split(":");
            int counter = 1;
            if (rows.Length == 0)
            {
                tbLog = $"Problem z wczytaniem pliku. Nie mogę utworzyć listy z promocja. Sprawdź poprawność separatora i nagłówka";
                return docList;
            }
            foreach (var item in rows)
            {
                try
                {
                    var itemList = item.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (itemList.Length > (13 > 3 ? 13 : 3))
                        docList.Add(new SpecialPriceModel { codeItem = itemList[3], salePriceBrutto = itemList[13].Replace("b", "") });
                }
                catch (Exception)
                {
                    tbLog = $"Problem z wczytaniem pliku w wierszu nr {counter}. {item}";
                }

            }
            tbLog = $"Wczytano {docList.Count()} pozycji";
            return docList;
        }
    }
}
