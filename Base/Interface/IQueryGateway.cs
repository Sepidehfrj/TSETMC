using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Interface
{
   public interface IQueryGateway
    {
       int? SelectMaxId(string whereClause = "");
    }
}
