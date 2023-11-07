using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
    public class CurrencyDto:BaseDto
    {
   
        public string PriceUnitCode { get; set; }
        public string PriceUnitTitle { get; set; }
        public string CDSTitle { get; set; }
        public int Action { get; set; }
    }
}
