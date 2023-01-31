using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBaseForm.BsLogic.SaleFromFiles.Dto
{
    internal class DtoSpecialPrice
    {
        public int IdItem { get; set; }
        public string specialPriceName { get; set; }
        public string codeItem { get; set; }
        public decimal salePriceBrutto { get; set; }
        public decimal oldPriceBrutto { get; set; }
        public int typePrice { get; set; }
        public DateTime saleFrom { get; set; }
        public DateTime saleTo { get; set; }
    }
}
