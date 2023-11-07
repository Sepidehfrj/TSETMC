using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
    public class ProductSubTypeDto:BaseDto
    {
 
        public string ProductSubTypeCode { get; set; }
        public string ProductSubTypeTitle { get; set; }
        public int Action { get; set; }
    }
}
