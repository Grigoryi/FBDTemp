using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
 public abstract  class OutputAlgoritm : IAlgoritmModel
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
     protected object _input;
     public object Input
     {
         get { return _input; }
         set 
         {
             if (_input == value) return;
             _input = value;
             AlgoritmUpdated(this, new AlgoritmEventArgs(this));
         
         }
     
     }
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
         return _input;
     }
  
     public object GetOutput()
     {
         return null;
     }
     #endregion



    
    }
}
