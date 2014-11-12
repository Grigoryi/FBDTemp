using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
    interface IIOAlgoritm : IAlgoritmModel
    {
      //  void SetOutput(int pos, object value);
        void SetInput(int pos, object value);
    }
}
