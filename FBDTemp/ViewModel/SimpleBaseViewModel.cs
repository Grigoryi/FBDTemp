using FBDTemp.Commands;
using FBDTemp.Model;
using FBDTemp.Model.Algoritms;
using FBDTemp.Model.Interfaces;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FBDTemp.ViewModel
{
  public  class SimpleBaseViewModel: DesignerBlockViewModel
    {
     
      private readonly IResizableAlg _model;
      #region Commands
      private ICommand _addInputCommand;
      public ICommand AddInputCommand
      {
          get 
          {
             if(_addInputCommand == null)
             {
                 _addInputCommand = new FBDTemp.Commands.DelegateCommand(AddInput, CanAddInput);
             }
              return _addInputCommand;
          }
      }

      private bool CanAddInput(object obj)
      {


          if (Input.Count >= _model.MaxCountInput ||
                  (_model.CountInpEqualCountOutp && Output.Count == _model.MaxCountOutput)) return false;
              else return true;
          
         
          
      }
      private void AddInput(object parameter)
      {

          _model.AddInput();
          if (_model.CountInpEqualCountOutp) _model.AddOutput();
           
         // UpdateBlock();
      }
      private ICommand _removeInputCommand;
      public ICommand RemoveInputCommand
      {
          get
          {
              if (_removeInputCommand == null)
              {
                    _removeInputCommand = new FBDTemp.Commands.DelegateCommand(RemoveInput, CanRemoveInput);
              }
              return _removeInputCommand;
          }
      }
      private void RemoveInput(object parameter)
      {
          _model.RemoveInput(Input.Count - 1);
      } 
      private bool CanRemoveInput(object obj)
      {
          
             // if(mod.CountInpEqualCountOutp && (mod.In))
              if (!Input[Input.Count - 1]._model._context.IsNeed ) return true; ///пока так, потом надо добавить условий
              else return false;
          
          
      }

      #endregion



      public ObservableCollection<SimpleIOBaseViewModel> Input
      {
          get;
          set;
      }

      public ObservableCollection<SimpleIOBaseViewModel> Output
      {
          get;
          set;
      }

      public string Name
      { get { return _model.AlgoritmName; } }

      //конструктор для создания отдельного блока
      public SimpleBaseViewModel(BaseAlgoritm algoritm, Guid id)
      {
          _model = algoritm;
          _id = id;
        //  _model.AlgoritmUpdated+=_model_AlgoritmUpdated;
          Init();
        
      }
      
      public SimpleBaseViewModel(int id, DiagramViewModel parent, double left, double top, BaseAlgoritm algoritm)
          : base(id,parent,left,top)
      {
          _model = algoritm;
          Init();
      }

      private Guid _id;
      public Guid ID
      {
          get
          {
             return _id;
          }
          set
          {
             if(_id != value)
              _id = value;
             // PropertyChanged(this, new PropertyChangedEventArgs("ID"));
              NotifyChanged("ID");
          }
      }
      private void Init()
      {
          if (_model.MinCountOutput > 0)
          {
              Output = new ObservableCollection<SimpleIOBaseViewModel>();
              for (int i = 0; i < _model.MinCountOutput; i++)
              {
                  Output.Add(new SimpleIOBaseViewModel(new SimpleInputAlgoritm(), i + 1));
              }
          }
          if (_model.MinCountInput > 0)
          {
              Input = new ObservableCollection<SimpleIOBaseViewModel>();
              for (int i = 0; i < _model.MinCountInput; i++)
              {
                  Input.Add(new SimpleIOBaseViewModel(new SimpleOutputAlgoritm(), i + 1));
              }
          }
      }

     
      #region NotifyPropertyChanged
      //public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
      //protected virtual void OnPropertyChanged(string propertyName)
      //{
      //    this.VerifyPropertyName(propertyName);
      //    PropertyChangedEventHandler handler = this.PropertyChanged;
      //    if (handler != null)
      //    {
      //        var e = new PropertyChangedEventArgs(propertyName);
      //        handler(this, e);
      //    }
      //}
      //[Conditional("Debug")]
      //[DebuggerStepThrough]
      //public void VerifyPropertyName(string propertyName)
      //{
      //    if (TypeDescriptor.GetProperties(this)[propertyName] == null)
      //    {
      //        string msg = "Invalid property name: " + propertyName;
      //        Debug.Fail(msg);
      //    }
      //}
      #endregion
    }
}
