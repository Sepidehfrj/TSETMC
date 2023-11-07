using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
    public class TradeTypeDto:BaseDto
    {
  
        public string TradeTypeCode { get; set; }
        public string TradeTypeVal { get; set; }
        public int Action { get; set; }
    }
}
