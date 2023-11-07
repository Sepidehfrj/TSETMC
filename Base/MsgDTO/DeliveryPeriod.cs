using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.MsgDTO
{
   public class DeliveryPeriod
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Action { get; set; }
    }
}
