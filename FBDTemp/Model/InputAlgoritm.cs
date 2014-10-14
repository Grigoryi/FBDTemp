using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public abstract class InputAlgoritm : IAlgoritmModel
    {
     
      private object _output;
      public object Output 
      { 
          get { return _output; }
          protected set 
          { 
              if(_output==null) _output = new object();
              _output = value;
          }
      }
        public virtual void Run()
        {
            
        }
        private object _visualContent;
        public object VisualContent
        {
            get { return _visualContent; }
            protected set
            {
                if (_visualContent == null) _visualContent = new object();
                _visualContent = value; 
            }
        }
        protected string _algoritmname;
        public string AlgoritmName
        {
            get { return _algoritmname; }
            set { _algoritmname = value; }
            
            
        }
        public event EventHandler AlgoritmCalculated = delegate { };
    }
}
