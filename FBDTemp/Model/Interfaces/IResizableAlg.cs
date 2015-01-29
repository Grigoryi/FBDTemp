using FBDTemp.Model.Algoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
  public  interface IResizableAlg 
    {
        SimpleOutputAlgoritm AddInput();
        bool CanAddInput();
        SimpleOutputAlgoritm RemoveInput(int position);
        SimpleOutputAlgoritm RemoveInput(SimpleOutputAlgoritm item);
        bool CanRemoveInput(int position);
        bool CanRemoveInput(SimpleOutputAlgoritm item);

        
    }
}
