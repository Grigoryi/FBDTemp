using FBDTemp.Helpers;
using FBDTemp.Model;
using FBDTemp.Model.Interfaces;
using FBDTemp.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace FBDTemp.ViewModel
{
  public class SimpleIOBaseViewModel : DesignerBlockViewModel
    {
      private IIOAlgoritm<object> _model;

      public IIOAlgoritm<object> Algoritm
      { get { return _model; } }

      public  SettingCollection BlockParametrs;

      public readonly SimpleBaseViewModel Owner;
      private double OwnerX;   //для запоминания прошлого положения
      private double OwnerY;

      public FullyCreatedConnectorInfo connector {get;set;}

      #region Command
      private ICommand _showParametrsCommand;
      public ICommand ShowParametrsCommand
      {
          get
          {
              if (_showParametrsCommand == null)
              {
                  _showParametrsCommand = new FBDTemp.Commands.DelegateCommand(ShowParametrs);
              }
              return _showParametrsCommand;
          }
      }
      private void ShowParametrs(object parameter)
      {
          SimpleUIVisualizerService visualservice = new SimpleUIVisualizerService();
          //visualservice.ShowDialog(BlockParametrs);
          visualservice.ShowDialog(this);
      }
      #endregion

      public string Name
      { get { return _model.AlgoritmName; } }

      public object Value //нужно обеспечить закрытие этого элемента когда блок находится в составе другого блока
      {
          get
          {
             return _model.GetValue();
          }
          set
          {
              if (_model.GetValue() != value)
              {
                  _model.SetValue(value);
                  NotifyChanged("Value");
                  //_model.Run();
              }
           }
          
      }
      private bool _isActual;

      public bool IsActual
      {
          get { return (bool)BlockParametrs["IsActual"].Value; }
          set
          {
              if (BlockParametrs["IsActual"] == null) BlockParametrs.Add(new CustomProperty("IsActual", true, true, typeof(bool)));
              if ((bool)BlockParametrs["IsActual"].Value != value)
              {
                  BlockParametrs["IsActual"].Value = value;
                  NotifyChanged("IsActual");
              }
          }
      }
      //конструктор для создания отдельного блока
      public SimpleIOBaseViewModel(int id, DiagramViewModel parent, double left, double top, IIOAlgoritm<object> algoritm)
      :base(id,parent,left,top)
      {
          _model = algoritm;
       //   Value = 0;
          Init();
      }
      /// <summary>
      /// Создает блок который является входом/выходом для другого блока
      /// </summary>
      /// <param name="id"></param>
      /// <param name="algoritm"></param>
      /// <param name="owner"></param>
      public SimpleIOBaseViewModel(int id, IDiagramViewModel parent, double left, double top, IIOAlgoritm<object> algoritm, SimpleBaseViewModel owner)
          : base(id, parent, left, top)
      {
          
          _model = algoritm;
          Owner = owner;
          OwnerX = Owner.Left;
          OwnerY = Owner.Top;

          if(algoritm is InputAlgoritm<object>)
          {
              this.Left = OwnerX + Owner.ItemWidth;
             
          }
          else if(algoritm is OutputAlgoritm<object>)
          {
              this.Left = OwnerX;
          }
          this.Top = OwnerY + Owner.TitleHeight + this.ItemHeight  * (id - 1);
          Init();
          (Owner as INotifyPropertyChanged).PropertyChanged += new WeakINPCEventHandler(SimpleIOBaseViewModel_PropertyChanged).Handler;

          
      }


    
      private void Init()
      {
          ConnectorOrientation orient;
          if (_model is InputAlgoritm<object>) orient = ConnectorOrientation.Right;
          else if (_model is OutputAlgoritm<object>) orient = ConnectorOrientation.Left;
          else orient = ConnectorOrientation.None;

          connector = new FullyCreatedConnectorInfo(this, orient);

          BlockParametrs = new SettingCollection(_model);
          BlockParametrs.Add(new CustomProperty("IsActual", true, true, typeof(bool)));
          BlockParametrs["IsActual"].Value = true;
      }

      private void SimpleIOBaseViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
          switch (e.PropertyName)
          {
              case "Left":
                  {
                      this.Left -= OwnerX - Owner.Left;
                      OwnerX = Owner.Left;
                      break;
                  }
              case "Top":
                  {
                      this.Top -= OwnerY - Owner.Top;
                      OwnerY = Owner.Top;
                      break;
                  }
                  
                  

          }
      }
    }
}
