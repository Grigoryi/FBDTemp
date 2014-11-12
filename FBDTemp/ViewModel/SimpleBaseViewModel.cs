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
  public  class SimpleBaseViewModel: INotifyPropertyChanged
    {
     
      private readonly IAlgoritmModel _model;
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
          if (_model is IResizableAlg)
          {
              var mod = (IResizableAlg)_model;
              if (Input.Count >= mod.MaxCountInput ||
                  (mod.CountInpEqualCountOutp && Output.Count == mod.MaxCountOutput)) return false;
              else return true;
          } else return false;
         
          
      }
      private void AddInput(object parameter)
      {
          var mod = (IResizableAlg)_model;
          mod.AddInput();
             if (mod.CountInpEqualCountOutp) mod.AddOutput();
           
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
          (_model as IResizableAlg).RemoveInput(Input.Count - 1);
      } 
      private bool CanRemoveInput(object obj)
      {
          if (_model is IResizableAlg) 
          {
              var mod = (IResizableAlg)_model;
             // if(mod.CountInpEqualCountOutp && (mod.In))
              if (Input[Input.Count - 1].CanDelete()) return true; ///пока так, потом надо добавить условий
              return true;
          }
          else return false;
      }

      #endregion



      public ObservableCollection<SimpleOutputAlgoritm> Input
      { get { return  (ObservableCollection<SimpleOutputAlgoritm>)_model.GetInput(); } }

      public ObservableCollection<SimpleInputAlgoritm> Output
      { get { return (ObservableCollection<SimpleInputAlgoritm>)_model.GetOutput(); } }

      public string Name
      { get { return _model.AlgoritmName; } }

      public SimpleBaseViewModel(IAlgoritmModel algoritm, Guid id)
      {
          _model = algoritm;
          _model.Block = new BaseBlock(algoritm, id);
          _model.AlgoritmUpdated+=_model_AlgoritmUpdated;
        
        
      }

      private void _model_AlgoritmUpdated(object sender, AlgoritmEventArgs e)
      {
          
      }




      private Guid _id;
      public Guid ID
      {
          get
          {
             return _model.Block.ID;
          }
          set
          {
              _model.Block.ID = value;
              PropertyChanged(this, new PropertyChangedEventArgs("ID"));
          }
      }

     
      #region NotifyPropertyChanged
      public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged(string propertyName)
      {
          this.VerifyPropertyName(propertyName);
          PropertyChangedEventHandler handler = this.PropertyChanged;
          if (handler != null)
          {
              var e = new PropertyChangedEventArgs(propertyName);
              handler(this, e);
          }
      }
      [Conditional("Debug")]
      [DebuggerStepThrough]
      public void VerifyPropertyName(string propertyName)
      {
          if (TypeDescriptor.GetProperties(this)[propertyName] == null)
          {
              string msg = "Invalid property name: " + propertyName;
              Debug.Fail(msg);
          }
      }
      #endregion
    }
}
