using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public abstract  class CompositionAlgoritm: BaseAlgoritm
    {
      private ICollection<IBlockModel> _blocks;
      public ICollection<IBlockModel> Blocks
      { 
          get { return _blocks; }
          set { _blocks = value; }
      }
      
      
    }
}
