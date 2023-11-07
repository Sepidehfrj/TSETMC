using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
    public class ProductTypeDto:BaseDto
    {
    
        public string ProductTypeCode { get; set; }
        public string ProductTypeTitle { get; set; }
        public int Action { get; set; }
    }
}
