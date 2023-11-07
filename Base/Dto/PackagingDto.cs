using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class PackagingDto:BaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Action { get; set; }
    }
}
