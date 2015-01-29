using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDConfigurator.Interfaces
{
   public interface IEditDialog<T> : IWindow
    {
       T Entity { get; set; }
    }
}
