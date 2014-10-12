using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
   public interface IConnection
    {
       IBlockModel From { get; set; }
       IBlockModel To { get; set; }
    }
}
