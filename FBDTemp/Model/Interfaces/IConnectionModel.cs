using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
   public interface IConnectionModel
    {
       InputAlgoritm<object> From { get; }
       int FromPort { get; }

       OutputAlgoritm<object> To { get; }
       int ToPort { get; }
      
       object Value { get; }
      
       int ID { get; }

      
    }
}
