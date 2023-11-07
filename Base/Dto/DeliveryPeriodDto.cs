using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class DeliveryPeriodDto:BaseDto
    {
   
        public string Code { get; set; }
        public string Name { get; set; }
        public int Action { get; set; }
    }
}
