using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
    public enum StateBlockEnum 
    { 
    ChangedInput,
        Ready,
        Calculated
    }
  public  interface IStateBlockModel
    {
      StateBlockEnum State { get; set; }
      void DoWork();
    }
}
