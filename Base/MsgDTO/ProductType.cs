using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.MsgDTO
{
    public class ProductType
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeTitle { get; set; }
        public int Action { get; set; }
    }
}
