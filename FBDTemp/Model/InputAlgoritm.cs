using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
    public abstract class InputAlgoritm : IAlgoritmModel
    {
      
    
      protected IBlockModel _block;
        public IBlockModel Block
        {
            get { return _block; }
            set
            {
                if (_block != value) _block = value;
            }
        }
    
      protected object _output;
      public object Output 
      { 
          get { return _output; }
          set
          {
              if (_output == value) return;
              _output = value;
              AlgoritmCalculated(this, new EventArgs());
          }
      }
      
       
      public virtual void Run()
        {
          //  AlgoritmCalculated(this, new EventArgs());
        }
        protected object _visualContent;
        public object VisualContent
        {
            get { return _visualContent; }
           // set { _visualContent = value;}
        }
        protected string _algoritmName;
        public string AlgoritmName
        {
            get { return _algoritmName; }
           // set { _algoritmname = value; }
            
            
        }
        public event EventHandler AlgoritmCalculated = delegate { };
        public event EventHandler<AlgoritmEventArgs> AlgoritmUpdated = delegate { };

        private object _parametrs;
        public object Parametrs
        {
            get { return _parametrs; }
            set { _parametrs = value; }
        }

        public object GetInput()
        {
            return null;
        }

        public object GetOutput()
        {
            return _output;
        }


    }
}
