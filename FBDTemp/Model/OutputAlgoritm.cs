using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
 public abstract  class OutputAlgoritm : IIOAlgoritm
    {
     
        
    protected IConnectionModel _connection;
    public IConnectionModel Connection 
     {
         get { return _connection; } 
         set 
         {
             if (_connection != null || _connection == value) return;
             _connection = value;
             AlgoritmUpdated(this,new AlgoritmEventArgs(this));
         } 
     }
     
     #region IBlockAlgoritm
     public virtual void Run()
     {
         AlgoritmCalculated(this, new EventArgs());   ///событие должно привязаться к соединению, чтобы соединяемый вход блока поменял свое значение
     }
     protected object _visualContent;
     public object VisualContent
     {
         get { return _visualContent; }
       
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
     
     public object _input;

     public void SetValue(object val)
     {
         if (_input == val) return;
         _input = val;
         AlgoritmUpdated(this, new AlgoritmEventArgs(this));
         
     }

     public object GetValue()
     {
         return _input;
     }
     public IConnectorModel _context { get; private set; }
    
     #endregion



    
    }
}
