using FBDTemp.Model.Algoritms;
using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FBDTemp.Model
{
  public abstract class BaseAlgoritm : IResizableAlg
    {
      protected ObservableCollection<SimpleInputAlgoritm> _outputs;
      public ObservableCollection<SimpleInputAlgoritm> Outputs
      {
          get 
          { 
            if (_outputs ==null)
            {
                _outputs = new ObservableCollection<SimpleInputAlgoritm>();
                _outputs.CollectionChanged += _outputs_CollectionChanged;
            }
              return _outputs; 
          }
         
      }

      void _outputs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
      {
          if(e.NewItems !=null && e.NewItems.Count!=0)
          {
              foreach(SimpleInputAlgoritm sia in e.NewItems)
              {
                  sia.ContextId = _outputs.IndexOf(sia);
                  AlgoritmUpdated(this, new AlgoritmEventArgs(sia));
              }
          }

      }
      protected ObservableCollection<SimpleOutputAlgoritm> _inputs;
      public ObservableCollection<SimpleOutputAlgoritm> Inputs
      {
          get 
          { 
             if(_inputs == null)
             {
                 _inputs = new ObservableCollection<SimpleOutputAlgoritm>();
                 _inputs.CollectionChanged += _inputs_CollectionChanged;
             }
              return _inputs; 
          }
      }

      void _inputs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
      {
          if (e.NewItems != null && e.NewItems.Count != 0)
          {
              foreach (SimpleOutputAlgoritm soa in e.NewItems)
              {
                  soa.ContextId = _inputs.IndexOf(soa);
                  AlgoritmUpdated(this, new AlgoritmEventArgs(soa));
              }
          }
          if (e.OldItems != null && e.OldItems.Count != 0)
              foreach (SimpleOutputAlgoritm soa in e.OldItems)
                  MessageBox.Show(soa.ContextId.ToString());
      }

      #region IAlgoritmModel
     
      public virtual void Run()
      {
          AlgoritmCalculated(this, new EventArgs());
      }
      protected object _visualContent;
      public object VisualContent
      {
          get 
          {
              if (_visualContent == null) _visualContent = _algoritmname;
              return _visualContent; 
          }
          set { 
              _visualContent = value;
              AlgoritmUpdated(this,new AlgoritmEventArgs(this));
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

      private object _parametrs;
      public object Parametrs
      {
          get { return _parametrs; }
          set { _parametrs = value; }
      }

      public object GetInput()
      {
          return _inputs;
      }

      public object GetOutput()
      {
          return _outputs;
      }
     
      #endregion

       //минимальное/максимальное количество входов/выходов
      public int MinCountInput { get;  set; }
      public int MinCountOutput { get; set; }
      public int MaxCountInput { get;  set; }
      public int MaxCountOutput { get; set; }

      public bool CountInpEqualCountOutp { get; set; }
      
     
      public void AddInput()
      {
          if (_inputs.Count == MaxCountInput) return; //нужно добавить исключение
         
             
               if (_inputs == null) _inputs = new ObservableCollection<SimpleOutputAlgoritm>();
              
          SimpleOutputAlgoritm soa = new SimpleOutputAlgoritm((Type)Parametrs);
              _inputs.Add(soa);
              AlgoritmUpdated(this, new AlgoritmEventArgs(soa));
             
       }
      public void AddOutput()
      {
          if (_outputs.Count == MaxCountOutput) return; //нужно добавить исключение
   
          if (_outputs == null) _outputs = new ObservableCollection<SimpleInputAlgoritm>();
             
          SimpleInputAlgoritm sia = new SimpleInputAlgoritm((Type)this._parametrs);   
             _outputs.Add(sia);////нужно добавить поиск необходимого типа в списке параметров
           AlgoritmUpdated(this, new AlgoritmEventArgs(sia));
         
      }
      public void RemoveInput(int pos)
      {
          if (_inputs.Count < pos + 1 || _inputs == null) return;
         
          if (!_inputs[pos].CanDelete() || _inputs.Count == MinCountInput) return;
                            
          var input = _inputs[pos];        
          _inputs.RemoveAt(pos);
           AlgoritmUpdated(this, new AlgoritmEventArgs(input));
        
         
      }
      public void RemoveOutput(int pos)
      {
          if (_outputs.Count < pos + 1) return;
         
          if (!_outputs[pos].CanDelete() || _inputs.Count == MinCountOutput) return;
          
          var output = _outputs[pos];
           _outputs.RemoveAt(pos);
           AlgoritmUpdated(this, new AlgoritmEventArgs(output));

      }


    }
}
