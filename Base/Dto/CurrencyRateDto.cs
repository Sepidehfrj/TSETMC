using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TseTmc.Base.Enum;

namespace TseTmc.Base.Dto
{
  public  class CurrencyRateDto:BaseDto
    {

        //public string PriceUnitCode { get; set; }
        //public string PriceUnitTitle { get; set; }
        public string TradeDate { get; set; }
        public int PriceUnitForm { get; set; }
        public int PriceUnitTo { get; set; }
        public string Currencyrate { get; set; }
        public string CreationDate { get; set; }
        public CurrencyRateStatus Status { get; set; }
        public ActionEnum Action { get; set; }






    }
}
