using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TseTmc.Base.MsgDTO
{
    public class CurrencyRate
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }


        public string TradeDate { get; set; }
        public string PriceUnitFrom { get; set; }
        public string PriceUnitTo { get; set; }

        [XmlElement("CurrencyRate")]
        public string Currencyrate { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
        public int Action { get; set; }
    }
}
