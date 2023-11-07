using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
    public class VolUnitConvertDto:BaseDto
    {

        public int UnitFrom { get; set; }
        public int UnitTo { get; set; }
        public string UnitVal { get; set; }
        public int Action { get; set; }
    }
}
