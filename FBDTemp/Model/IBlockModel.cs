using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
   public interface IBlockModel
    {
       IAlgoritmModel Algoritm { get; set; }
       Guid ID { get; set; }
       ICollection<IConnection> Connections { get; set; }
    }
}
