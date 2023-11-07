using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base
{
   public interface ITableGateway<T> where T : BaseDto
    {
        ICollection<T> Select(string whereClause = "");
        int Update(T dto);
        int Insert(T dto);

    }
}
