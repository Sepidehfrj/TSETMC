using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class PrePaymentDto:BaseDto
    {
    
        public string PrePaymentPercent { get; set; }
        public int Action { get; set; }
    }
}
