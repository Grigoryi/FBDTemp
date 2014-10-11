using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public abstract class InputAlgoritm : IAlgoritm
    {
      public Dictionary<string, object> output;
        
        public virtual void Run()
        {
            
        }
        private object _visualContent;
        public object VisualContent
        {
            get { return _visualContent; }
        }
        protected string _algoritmname;
        public string AlgoritmName
        {
            get
            {
                return _algoritmname;
            }
            
        }
    }
}
