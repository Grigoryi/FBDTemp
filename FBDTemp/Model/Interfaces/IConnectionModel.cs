using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
   public interface IConnectionModel
    {
       InputAlgoritm From { get; }
      // int FromPort { get; }

       OutputAlgoritm To { get; }
     //  int ToPort { get; }
      
       object Value { get; }
      
       Guid ID { get; }

      
    }
}
