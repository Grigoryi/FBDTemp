using FBDTemp.Model.Algoritms;
using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FBDTemp.Model
{
  public abstract class BaseAlgoritm : IAlgoritmModel
    {
        
    
      protected List<SimpleInputAlgoritm> _outputs;
      public List<SimpleInputAlgoritm> Outputs
      {
          get
          {
              return _outputs;
          }
          set
          {
              if (_outputs == value) return;

              _outputs = value;
              AlgoritmUpdated(this, new AlgoritmEventArgs(this));
          }
      }

      protected List<SimpleOutputAlgoritm> _inputs;
      public List<SimpleOutputAlgoritm> Inputs
      {
          get { return _inputs; }
          set
          {
              if (_inputs == value) return;

              _inputs = value;
              AlgoritmUpdated(this, new AlgoritmEventArgs(this));
          }
      }
      

      #region IAlgoritmModel
     
      public virtual void Run()
      {
          AlgoritmCalculated(this, new EventArgs());
      }
      public virtual void Reset()
      {

      }

      private object _visualContent;
      public object VisualContent
      {
          get 
          {
              if (_visualContent == null) _visualContent = _algoritmname;
              return _visualContent; 
          }
          set {
              if (_visualContent == value) return;
              _visualContent = value;
              AlgoritmUpdated(this,new AlgoritmEventArgs(this, CommandType.None));
          }
      }
     
      protected string _algoritmname;
      public string AlgoritmName
      {
          get { return _algoritmname; }
        //  set { _algoritmname = value; }


      }
      
      public event EventHandler AlgoritmCalculated = delegate { };
      public event EventHandler<AlgoritmEventArgs> AlgoritmUpdated = delegate { };

      private SettingCollection _parametrs;
      public SettingCollection Parametrs
      {
          get { return _parametrs; }
          set { _parametrs = value; }
      }

      public BaseAlgoritm()
      {
          Init();
      }
     
      protected virtual void Init()
      {
          _inputs = new List<SimpleOutputAlgoritm>();
          _outputs = new List<SimpleInputAlgoritm>();

          _parametrs = new SettingCollection(this);
      }
     
      #endregion

     

    }
}
