using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class ClearingTypeDto: BaseDto
    {
        public string ClearingTitle { get; set; }
        public int Action { get; set; }
    }
}
