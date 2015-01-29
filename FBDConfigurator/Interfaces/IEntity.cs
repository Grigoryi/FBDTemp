using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDConfigurator.Interfaces
{
   public interface IEntity
    {
       int id { get; set; }
    }
    public interface INamedEntity : IEntity
    {
        string name { get; set; }
    }
}
