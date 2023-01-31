using OptimaBaseForm.Optima;
using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.BsLogic.SaleFromFiles
{
    public class SaleFromFile
    {
        public static string Add()
        {
            string log = "";

            var listSpecialPrice = Config.GetMapping(MappingTypeDB.SpecialPrice);

            string specialOfferName = Settings.Default.SpecialOfferNameSFF;
            DateTime dateFrom = Settings.Default.SpecialOfferFrom;
            DateTime dateTo = Settings.Default.SpecialOfferTo;
            int priceType = Settings.Default.SpecialOfferPriceTypeIdSFF;
            var specialOfferData = FileToRead.SpecialOfferFile(Settings.Default.FilePathSFF, log);

            if (specialOfferData.Count() == 0)
                return log = "Brak danych do wczytania, Sprawdź konfiguracje";
            if (specialOfferName == "")
                return log = $"Wprowadź nazwe promocji";

            if (listSpecialPrice.Rows.Count > 0)
            {
                foreach (DataRow item in listSpecialPrice.Rows)
                {
                    var dateFromMapp = Convert.ToDateTime(item["Map_AddItemValue"]);
                    if (item["Map_OptValue"].ToString() == specialOfferName)
                    {
                        MessageBox.Show($"Promocja o tej nazwie {specialOfferName} już istnieje w bazie. Nazwa promocji musi być unikalna.", "Nowa promocja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return log;
                    }
                    else if (Convert.ToInt32(item["Map_OptId"]) == priceType && DateTime.Compare(dateFrom, dateFromMapp) < 0)
                    {
                        MessageBox.Show($"Zaprogramowano promocje {specialOfferName} dla grupy ceny {priceType} w okresie od {dateFrom} do {dateTo}. Nowa promocja nie może mieć takie samego typu ceny nr {priceType} w tym samym okresie", "Nowa promocja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return log;
                    }
                    else
                    {                       
                        OptSpecialPrices.CreateSpecialPricesFromTo(specialOfferData, specialOfferName, dateFrom, dateTo, priceType, log);
                        Config.AddMaping(0, specialOfferName, 0, dateFrom.ToString(), 0, dateTo.ToString(), MappingTypeDB.SpecialPrice);
                    }
                }
            }
            else
            {
                OptSpecialPrices.CreateSpecialPricesFromTo(specialOfferData, specialOfferName, dateFrom, dateTo, priceType, log);
                Config.AddMaping(priceType, specialOfferName, 0, dateFrom.ToString(), 0, dateTo.ToString(), MappingTypeDB.SpecialPrice);
            }


            return log;
        }

        public static string Delete(int idRow, string specialPricesName)
        {
            string log = "";
            
            if (MessageBox.Show("Czy na pewno chcesz usunac zaznaczoną promocje?", "Usuwanie", MessageBoxButtons.YesNo) == DialogResult.No) return log;
            try
            {
               
                var succes = OptSpecialPrices.DeleteSpecialPricesFromTo(specialPricesName);
                Config.DeleteMaping(idRow);
                //LoadMapping(dgvSpecialPrice, MappingTypeDB.SpecialPrice, bsSpecialPrice);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie zaznaczono elementu do usunięcia", "Usuwanie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return log;
            }

            return log;
        }

    }
}
