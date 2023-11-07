using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.MsgDTO
{
   public class Currency
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string PriceUnitCode { get; set; }
        public string PriceUnitTitle { get; set; }
        public string CDSTitle { get; set; }
        public int Action { get; set; }
    }
}
