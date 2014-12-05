using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
    public abstract class InputAlgoritm : IIOAlgoritm
    {
    
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
            set { _algoritmName = value; }
            
            
        }
        public event EventHandler AlgoritmCalculated = delegate { };
        public event EventHandler<AlgoritmEventArgs> AlgoritmUpdated = delegate { };

        private object _parametrs;
        public object Parametrs
        {
            get { return _parametrs; }
            set { _parametrs = value; }
        }

        protected object _output;
       
        public void SetValue(object val)
        {
            if (_output == val) return;
            _output = val;
            AlgoritmCalculated(this, new EventArgs());
        }
        public object GetValue()
        {
            return _output;
        }
        public IConnectorModel _context { get; private set; }

    }
}
