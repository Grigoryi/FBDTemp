using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
  public  interface IIOAlgoritm<T> : IAlgoritmModel
    {
       //void SetValue(object var);
      T GetValue();
      void SetValue(T value);

      //Type TypeValue { get; set; }
      // IContextModel _context {get;}
    }
}
