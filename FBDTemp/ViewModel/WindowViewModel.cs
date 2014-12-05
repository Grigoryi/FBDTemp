using FBDTemp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.ViewModel
{
  public  class WindowViewModel : Notifier
    {
      private DiagramViewModel _diagramViewModel = new DiagramViewModel();
      public DiagramViewModel DiagramViewModel
      {
          get
          {
              return _diagramViewModel;
          }
          set
          {
              if(_diagramViewModel != value)
              {
                  _diagramViewModel = value;
                  NotifyChanged("DiagramViewModel");
              }
          }
      }
      public WindowViewModel()
      {
          DiagramViewModel = new DiagramViewModel();
      }
    }
}
