using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public abstract  class CompositionAlgoritm
    {
      public Dictionary<string, object> input;

      private ObservableCollection<IAlgoritmModel> _algoritms;
      public ICollection<IAlgoritmModel> Algoritms
      {
          get { return _algoritms; }
      }
    }
}
