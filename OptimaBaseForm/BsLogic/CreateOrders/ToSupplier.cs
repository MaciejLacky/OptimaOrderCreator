using CDNBase;
using CDNHeal;
using CDNHlmn;
using CDNTwrb1;
using OptimaBaseForm.BsLogic.SaleFromFiles.DB;
using OptimaBaseForm.Optima;
using OptimaBaseForm.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.BsLogic.CreateOrders
{
    public static class ToSupplier
    {
        public static string Create(List<DtoOrderToSupplier> dto, int addIfZero, int defaultMin, int defaultMax, string kntCode, int idMag, ProgressBar prBar)
        {
            if (!Opt.LogIn()) return "błąd logowania Optima";
            int quantityToOrder;
            bool createDoc = false;
            string docNumbers = "";
            int counter = 0;
            prBar.Maximum= dto.Count();
            prBar.Step= 1;
            //prBar.Refresh();
            List<string> kntCodeList = new List<string>();
            if (Settings.Default.LastKntByOrder)
                foreach (var item in dto.DistinctBy(x => x.Knt_Kod))
                    kntCodeList.Add(item.Knt_Kod);
            if(Settings.Default.LastKntByOrder)
            {
                foreach (var item in kntCodeList)
                {
                    createDoc = false;                   
                    AdoSession session = Opt.Login.CreateSession();
                    //var zamDocs = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
                    DokumentyHaMag optDocuments = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
                    IDokumentHaMag optDocument = (IDokumentHaMag)optDocuments.AddNew(null);
                    optDocument.Rodzaj = 309000;
                    optDocument.TypDokumentu = 309;//zamowienie
                    optDocument.Bufor = 1;
                    optDocument.MagazynZrodlowyID = idMag;
                    optDocument.DataDok = DateTime.Now;
                    ICollection customers = (ICollection)session.CreateObject("CDN.Kontrahenci", null);
                    try
                    {
                        IKontrahent customer = (IKontrahent)customers["Knt_Kod='" + item + "'"];
                        optDocument.Podmiot = customer;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(" ToSupplier.Create() błąd dodania kontrahenta " + ex.Message);
                        return "błąd dodania kontrahenta";
                    }

                    try
                    {
                        ICollection positions = optDocument.Elementy;
                        foreach (var row in dto.Where(x=>x.Knt_Kod == item))
                        {
                            
                            quantityToOrder = 0;
                            // quantityToOrder = Convert.ToInt32(row["Ilosc_Spr"].ToString());                   
                            var Ilosc_Sp = Convert.ToInt32(row.Ilosc_Spr);
                            var TwI_Ilos = Convert.ToInt32(row.TwI_Ilosc);

                            if (addIfZero == 0 && row.TwI_Ilosc == 0)
                                quantityToOrder = row.Ilosc_Spr;
                            if (addIfZero > 0 && row.TwI_Ilosc == 0)
                                quantityToOrder = row.Ilosc_Spr + addIfZero;

                            if (defaultMax == 0 && row.TwI_Ilosc <= defaultMin && row.TwI_Ilosc > 0)
                                quantityToOrder = row.Ilosc_Spr;
                            if (defaultMax > 0 && row.TwI_Ilosc <= defaultMin)
                                quantityToOrder = defaultMax - row.TwI_Ilosc;

                            counter++;
                            prBar.Value = counter;
                            prBar.Refresh();

                            if (quantityToOrder == 0) continue;
                            createDoc = true;
                            ITowar optimaTowar = session.CreateObject("CDN.Towary", "Twr_TwrId= " + row.Twr_twrId);
                            IElementHaMag position = (IElementHaMag)positions.AddNew(null);
                            position.Towar = optimaTowar;
                            position.Ilosc = quantityToOrder;
                       

                        }
                        if (createDoc)
                        {
                            session.Save();
                            Log.Info($"Dodano zamówienie nr {optDocument.NumerPelny} dla kontrahenta {item} ");
                            docNumbers += optDocument.NumerPelny + " ";
                        }

                    }
                    catch (Exception ex)
                    {
                        Log.Error(" ToSupplier.Create() błąd dodania zamówienia " + ex.Message);
                    }
                }

            }
            else
            {
                AdoSession session = Opt.Login.CreateSession();
                //var zamDocs = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
                DokumentyHaMag optDocuments = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
                IDokumentHaMag optDocument = (IDokumentHaMag)optDocuments.AddNew(null);
                optDocument.Rodzaj = 309000;
                optDocument.TypDokumentu = 309;//zamowienie
                optDocument.Bufor = 1;
                optDocument.MagazynZrodlowyID = idMag;
                optDocument.DataDok = DateTime.Now;
                ICollection customers = (ICollection)session.CreateObject("CDN.Kontrahenci", null);
                try
                {
                    IKontrahent customer = (IKontrahent)customers["Knt_Kod='" + kntCode + "'"];
                    optDocument.Podmiot = customer;
                }
                catch (Exception ex)
                {
                    Log.Error(" ToSupplier.Create() błąd dodania kontrahenta " + ex.Message);
                    return "błąd dodania kontrahenta";
                }

                try
                {
                    ICollection positions = optDocument.Elementy;
                    foreach (var row in dto)
                    {
                       
                        quantityToOrder = 0;
                        // quantityToOrder = Convert.ToInt32(row["Ilosc_Spr"].ToString());                   
                        var Ilosc_Sp = Convert.ToInt32(row.Ilosc_Spr);
                        var TwI_Ilos = Convert.ToInt32(row.TwI_Ilosc);

                        if (addIfZero == 0 && row.TwI_Ilosc == 0)
                            quantityToOrder = row.Ilosc_Spr;
                        if (addIfZero > 0 && row.TwI_Ilosc == 0)
                            quantityToOrder = row.Ilosc_Spr + addIfZero;

                        if (defaultMax == 0 && row.TwI_Ilosc <= defaultMin && row.TwI_Ilosc > 0)
                            quantityToOrder = row.Ilosc_Spr;
                        if (defaultMax > 0 && row.TwI_Ilosc <= defaultMin)
                            quantityToOrder = defaultMax - row.TwI_Ilosc;

                        counter++;
                        prBar.Value = counter;
                        prBar.Refresh();

                        if (quantityToOrder == 0) continue;
                        createDoc = true;
                        ITowar optimaTowar = session.CreateObject("CDN.Towary", "Twr_TwrId= " + row.Twr_twrId);
                        IElementHaMag position = (IElementHaMag)positions.AddNew(null);
                        position.Towar = optimaTowar;
                        position.Ilosc = quantityToOrder;
                       
                        
                    }
                    if (createDoc)
                    {
                        session.Save();
                        Log.Info($"Dodano zamówienie nr {optDocument.NumerPelny} dla kontrahenta {kntCode}");
                        docNumbers += optDocument.NumerPelny + " ";
                    }

                }
                catch (Exception ex)
                {
                    Log.Error(" ToSupplier.Create() błąd dodania zamówienia " + ex.Message);
                }
            }
           
            Opt.Logout();
            return docNumbers;

        }

        //public static string Create(DataTable dt, int addIfZero, int defaultMin, int defaultMax, string kntCode, int idMag)
        //{
        //    if (!Opt.LogIn()) return "błąd logowania Optima";
        //    int quantityToOrder;
        //    bool createDoc = false;
        //    string docNumbers = "";
        //    AdoSession session = Opt.Login.CreateSession();
        //    //var zamDocs = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
        //    DokumentyHaMag optDocuments = (DokumentyHaMag)session.CreateObject("CDN.DokumentyHaMag", null);
        //    IDokumentHaMag optDocument = (IDokumentHaMag)optDocuments.AddNew(null);
        //    optDocument.Rodzaj = 309000;
        //    optDocument.TypDokumentu = 309;//zamowienie
        //    optDocument.Bufor = 1;
        //    optDocument.MagazynZrodlowyID = idMag;
        //    optDocument.DataDok = DateTime.Now;
        //    ICollection customers = (ICollection)session.CreateObject("CDN.Kontrahenci", null);
        //    try
        //    {
        //        IKontrahent customer = (IKontrahent)customers["Knt_Kod='" + kntCode + "'"];
        //        optDocument.Podmiot = customer;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(" ToSupplier.Create() błąd dodania kontrahenta " + ex.Message);
        //        return "błąd dodania kontrahenta";
        //    }

        //    try
        //    {
        //        ICollection positions = optDocument.Elementy;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            quantityToOrder = 0;
        //            // quantityToOrder = Convert.ToInt32(row["Ilosc_Spr"].ToString());
        //            var sss = row["Ilosc_Spr"];
        //            var Ilosc_Spr = Convert.ToInt32(row["Ilosc_Spr"]);
        //            var TwI_Ilosc = Convert.ToInt32(row["TwI_Ilosc"]);

        //            if (addIfZero == 0 && TwI_Ilosc == 0)
        //                quantityToOrder = Ilosc_Spr;
        //            if (addIfZero > 0 && TwI_Ilosc == 0)
        //                quantityToOrder = Ilosc_Spr + addIfZero;

        //            if (defaultMax == 0 && TwI_Ilosc <= defaultMin && TwI_Ilosc >0)
        //                quantityToOrder = Ilosc_Spr;
        //            if (defaultMax > 0 && TwI_Ilosc <= defaultMin)
        //                quantityToOrder = defaultMax - TwI_Ilosc;



        //            if (quantityToOrder == 0) continue;
        //            createDoc = true;
        //            ITowar optimaTowar = session.CreateObject("CDN.Towary", "Twr_TwrId= " + row["Twr_TwrId"]);
        //            IElementHaMag position = (IElementHaMag)positions.AddNew(null);
        //            position.Towar = optimaTowar;
        //            position.Ilosc = quantityToOrder;

        //        }
        //        if(createDoc)
        //        {
        //            session.Save();
        //            Log.Info($"Dodano zamówienie nr {optDocument.NumerPelny} dla kontrahenta {kntCode}");
        //            docNumbers += optDocument.NumerPelny + " ";
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(" ToSupplier.Create() błąd dodania zamówienia " + ex.Message);
        //    }
        //    Opt.Logout();
        //    return docNumbers;

        //}

        internal static List<DtoOrderToSupplier> Dto(DataTable data)
        {
            List<DtoOrderToSupplier> list = new List<DtoOrderToSupplier> { };
            DtoOrderToSupplier dto;
            try
            {
                foreach (DataRow row in data.Rows)
                {
                    dto = new DtoOrderToSupplier();
                    dto.Twr_twrId = (int)row["Twr_TwrId"];
                    dto.Twr_Kod = row["Twr_Kod"].ToString();
                    dto.Wartosc_Spr = Convert.ToDecimal(row["Wartosc_Spr"]);
                    dto.Ilosc_Spr = Convert.ToInt32(row["Ilosc_Spr"]);
                    dto.Twr_IloscMax = Convert.ToInt32(row["Twr_IloscMax"]);
                    dto.Twr_IloscMin = Convert.ToInt32(row["Twr_IloscMin"]);
                    dto.Twr_IloscZam = Convert.ToInt32(row["Twr_IloscZam"]);
                    dto.TwI_Ilosc = Convert.ToInt32(row["TwI_Ilosc"]);

                    list.Add(dto);

                }
            }
            catch (Exception ex)
            {
                Log.Error(" ToSupplier.Dto() błąd dodania do listy dto " + ex.Message);
            }
           return list;
        }

        public static void GetLastKntOnProducts(List<DtoOrderToSupplier> data)
        {
            foreach(var item in data)
            {
                var supplier = DbOrderToSupplier.GetLastKntToSupplierOrder(item.Twr_twrId);
                if (supplier.Rows.Count != 0)
                    item.Knt_Kod = supplier.Rows[0]["Knt_Kod"].ToString();
                else
                    item.Knt_Kod = Settings.Default.OrderRotationKnt;
            }
        }
    }

    public class DtoOrderToSupplier
    {
        public int Twr_twrId { get; set; }
        public string? Twr_Kod { get; set; }
        public int Ilosc_Spr { get; set; }
        public int TwI_Ilosc { get; set; }
        public int Twr_IloscMin { get; set; }
        public int Twr_IloscMax { get; set; }
        public int Twr_IloscZam { get; set; }
        public decimal Wartosc_Spr { get; set; }
        public string? Knt_Kod { get; set; }
    }
}
