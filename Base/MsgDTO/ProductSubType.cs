using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.MsgDTO
{
   public class ProductSubType
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string ProductSubTypeCode { get; set; }
        public string ProductSubTypeTitle { get; set; }
        public int Action { get; set; }
    }
}
