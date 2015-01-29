using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
 public  class OutputAlgoritm<T> : IIOAlgoritm<T>
    {
     
        
    protected IConnectionModel _connection;
    public IConnectionModel Connection 
     {
         get { return _connection; } 
         set 
         {
             if (_connection == value) return;
             //нужна проверка на соответсвие типов данных
             _connection = value;
             AlgoritmUpdated(this,new AlgoritmEventArgs(this,CommandType.None));
         } 
     }
    
 
    private bool _isInverse;
    public bool IsInverse
    {
        get { return _isInverse; }
        set { _isInverse = value; }

    }

    #region Ctors
     public OutputAlgoritm()
       {
         
           _algoritmName = "Вход";
           _visualContent = AlgoritmName;
           Init();
       }
   
       public OutputAlgoritm( string name, T obj)
       {
            _algoritmName = name;
            _visualContent = AlgoritmName;
            _input = obj;
            Init();
        }
    #endregion
     private void Init()
       {
           _parametrs = new SettingCollection(this);
       }
    #region IIOAlrotitm inherit
    public virtual void Run()
     {
         AlgoritmCalculated(this, new EventArgs());   
     }
     public virtual void Reset()
    {
        
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


     private SettingCollection _parametrs;
     public SettingCollection Parametrs
     {
         get { return _parametrs; }
         set { _parametrs = value; }
     }
     
     protected T _input;

     public virtual T GetValue()
     {
          return _input; }
    
     public virtual void SetValue(T val)
       {
           if (_input != null)
           {
               if (!_input.Equals(val))
               {
                   _input = val;
                   AlgoritmUpdated(this, new AlgoritmEventArgs(this, CommandType.None));
               }
           }
           else
           {
               _input = val;
               AlgoritmUpdated(this, new AlgoritmEventArgs(this, CommandType.None));
           }
         
     }
#endregion
    
     



    
    }
}
