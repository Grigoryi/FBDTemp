using FBDTemp.Model.Algoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
  public  interface IResizableAlg : IAlgoritmModel
    {
        void AddInput();
        void AddOutput();
        void RemoveInput(int position);
        void RemoveOutput(int position);

        int MinCountInput { get;  set; }
        int MinCountOutput { get; set; }
        int MaxCountInput { get;  set; }
        int MaxCountOutput { get; set; }

        bool CountInpEqualCountOutp { get;  set; }
    }
}
