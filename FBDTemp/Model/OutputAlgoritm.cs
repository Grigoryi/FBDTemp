using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
 public abstract  class OutputAlgoritm : IAlgoritmModel
    {

     private object _input;  
     public object Input
     {
         get { return _input; }
     }
     
     #region IBlockAlgoritm
     public virtual void Run()
     {

     }
     private object _visualContent;
     public object VisualContent
     {
         get { return _visualContent; }
         private set
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
     #endregion
    }
}
