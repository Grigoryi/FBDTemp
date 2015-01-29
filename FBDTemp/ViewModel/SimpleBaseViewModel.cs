using FBDTemp.Commands;
using FBDTemp.Model;
using FBDTemp.Model.Algoritms;
using FBDTemp.Model.Interfaces;
using FBDTemp.Services;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FBDTemp.ViewModel
{
  public  class SimpleBaseViewModel: DesignerBlockViewModel
    {
     
      public readonly BaseAlgoritm _model;



      public  SettingCollection BlockParametrs;
      #region Commands
      private DelegateCommand _addInputCommand;
      public ICommand AddInputCommand
      {
          get 
          {
             if(_addInputCommand == null)
             {
                 _addInputCommand = new DelegateCommand(AddInput, CanAddInput);
             }
              return _addInputCommand;
          }
      }

      private bool CanAddInput(object obj)
      {
          if (_model is IResizableAlg)
          {
             return (_model as IResizableAlg).CanAddInput();
              
          }
          else return false;
         
          
      }
      private void AddInput(object parameter)
      {
          SimpleOutputAlgoritm soa = (_model as IResizableAlg).AddInput();
          SimpleIOBaseViewModel viewmodel = new SimpleIOBaseViewModel(_input.Count+1, (DiagramViewModel)this.Parent, 0, 0, soa, this);
          viewmodel.IsActual = true;
          _input.Add(viewmodel);
          _addInputCommand.RaiseCanExecuteChanged();
          NotifyChanged("Input");
          NotifyChanged("InputToVisual");


      }
      private DelegateCommand _removeInputCommand;
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
        SimpleOutputAlgoritm soa = (_model as IResizableAlg).RemoveInput(_model.Inputs.Last());
        SimpleIOBaseViewModel item = _input.Where(i => i.Algoritm.Equals(soa)).First();
        _input.Remove(item);
        _removeInputCommand.RaiseCanExecuteChanged();
        NotifyChanged("Input");
        NotifyChanged("InputToVisual");
         
      } 
      private bool CanRemoveInput(object obj)
      {
          if (_model is IResizableAlg)
          {

              return (_model as IResizableAlg).CanRemoveInput(_model.Inputs.Last());
          }
          else return false;
      }

      private ICommand _showParametrsCommand;
      public ICommand ShowParametrsCommand
      {
          get
          {
              if(_showParametrsCommand == null)
              {
                  _showParametrsCommand = new FBDTemp.Commands.DelegateCommand(ShowParametrs);
              }
              return _showParametrsCommand;
          }
      }
      private void ShowParametrs(object parameter)
      {
          SimpleUIVisualizerService visualservice = new SimpleUIVisualizerService();
         // visualservice.ShowDialog(BlockParametrs);
          visualservice.ShowDialog(this);
      }
      #endregion


      private ObservableCollection<SimpleIOBaseViewModel> _input;
      public ObservableCollection<SimpleIOBaseViewModel> Input
      {
            get 
            {
                if (_input == null)
                {
                    _input = new ObservableCollection<SimpleIOBaseViewModel>();
                    _input.CollectionChanged += _inputs_CollectionChanged;
                }
                return _input; 
            }
            set{
            if( _input != value)
            {
                _input = value;
                NotifyChanged("Input");
            }
            }
         
      }
      public   ObservableCollection<SimpleIOBaseViewModel> InputToVisual
      { get { return new ObservableCollection<SimpleIOBaseViewModel>(_input.Where(n => (bool)n.IsActual == true)); } }
    

      private ObservableCollection<SimpleIOBaseViewModel> _output;
      public ObservableCollection<SimpleIOBaseViewModel> Output
      {
          get {
              if (_output == null)
              {
                  _output = new ObservableCollection<SimpleIOBaseViewModel>();
                  _output.CollectionChanged += _outputs_CollectionChanged;
              }
              return _output;
          }
          set
          {
              if (_output !=value)
              {
                  _output = value;
                  NotifyChanged("Output");
              }
          }
      }
          

           void _outputs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
           {
               if(e.NewItems !=null && e.NewItems.Count!=0)
               {
                   NotifyChanged("Output");
                   NotifyChanged("OutputToVisual");
               }

           }
          
          void _inputs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
           {
               if (e.NewItems != null && e.NewItems.Count != 0)
               {
                   NotifyChanged("Input");
                   NotifyChanged("InputToVisual");
               }
         
           }
           
      
      public string Name
      { get { return _model.AlgoritmName; } }
     /* {
          get { return Name; }
          set 
          {
              if (string.Compare(Name, value) != 0)
             {
                 Name = value;
                 NotifyChanged("Name");
             }
          }
      }*/

      public double ListItemHeight
      { get { return TitleHeight + 40; } }

     

      //конструктор для создания отдельного блока
      public SimpleBaseViewModel(BaseAlgoritm algoritm, int id)
      {
          _model = algoritm;
          this.ID = id;
          _model.AlgoritmCalculated += _model_AlgoritmCalculated;
          _model.AlgoritmUpdated +=_model_AlgoritmUpdated;
          Init();
        
      }

      

      void _model_AlgoritmCalculated(object sender, EventArgs e)
      {
          for (int i = 0; i < Output.Count; i++)
              _output[i].Value = _model.Outputs[i].GetValue();
      }
      
      public SimpleBaseViewModel(int id, DiagramViewModel parent, double left, double top, BaseAlgoritm algoritm)
          : base(id,parent,left,top)
      {
          _model = algoritm;
          _model.AlgoritmUpdated += _model_AlgoritmUpdated;
          Init();
      }

     
      private void Init()
      {
          BlockParametrs = new SettingCollection(_model);
          if (_model.Outputs.Count > 0)
          {
              _output = new ObservableCollection<SimpleIOBaseViewModel>();
              for (int i = 0; i < _model.Outputs.Count; i++)
              {
                // SimpleInputAlgoritm s = new SimpleInputAlgoritm(typeof(double));
                //  Type type = _model.Outputs[i].GetType();
                  SimpleInputAlgoritm s = _model.Outputs[i];
                  SimpleIOBaseViewModel sio = new SimpleIOBaseViewModel(i+1, (DiagramViewModel)this.Parent ,10.0 ,10.0 , s,this);
                  _output.Add(sio);
                  BlockParametrs.Add(sio.BlockParametrs["IsActual"]);
              }
          }
          if (_model.Inputs.Count > 0)
          {
              _input = new ObservableCollection<SimpleIOBaseViewModel>();
              for (int i = 0; i < _model.Inputs.Count; i++)
              {
                //  Type type = _model.Inputs[i].GetType();
                  SimpleOutputAlgoritm so = _model.Inputs[i];
                  SimpleIOBaseViewModel si = new SimpleIOBaseViewModel(i + 1,(DiagramViewModel)this.Parent,0,0, so, this);
                 
                  _input.Add(si);
                  BlockParametrs.Add(si.BlockParametrs["IsActual"]);
                 
              }
          }
          
      }

      #region
      void so_AlgoritmUpdated(object sender, AlgoritmEventArgs e)
      {
         // for (int i = 0; i < Output.Count; i++)
          //    _output[i].Value = _model.Outputs[i].GetValue();
      }
      private void _model_AlgoritmUpdated(object sender, AlgoritmEventArgs e)
      {
      /*    if(e.commandType == CommandType.Add)
          {
              if (e.Algoritm is SimpleInputAlgoritm)
              {
                  _output.Add(new SimpleIOBaseViewModel(_output.Count, this.Parent, 0, 0, (SimpleInputAlgoritm)e.Algoritm, this));
                  
              }
              else if (e.Algoritm is SimpleOutputAlgoritm)
              {
                  _input.Add(new SimpleIOBaseViewModel(_input.Count+1, this.Parent, 0, 0, (SimpleOutputAlgoritm)e.Algoritm, this));
                //  NotifyChanged("Input");
                  NotifyChanged("InputToVisual");
              }
          }
         */
      }
      #endregion


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
