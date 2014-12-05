using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
  public  interface IIOAlgoritm : IAlgoritmModel
    {
       void SetValue(object var);
       object GetValue();
       IConnectorModel _context {get;}
    }
}
