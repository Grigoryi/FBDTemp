using FBDTemp.Commands;
using FBDTemp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FBDTemp.ViewModel
{
  public  class WindowViewModel : Notifier
  {
      #region Private Fields
      private DiagramViewModel _diagramViewModel = new DiagramViewModel();
      private List<int> _savedDiagrams = new List<int>();
      private int? _savedDiagramId;
      private List<SelectableBlockViewModel> itemsToRemove;
      private bool _isBusy = false;
      #endregion

      #region Public Field
      public DiagramViewModel DiagramViewModel
      {
          get
          {
              return _diagramViewModel;
          }
          set
          {
              if(_diagramViewModel != value)
              {
                  _diagramViewModel = value;
                  NotifyChanged("DiagramViewModel");
              }
          }
      }
      public bool IsBusy
      {
          get { return _isBusy; }
          set
          {
              if (_isBusy != value)
              {
                  _isBusy = value;
                  NotifyChanged("IsBusy");
              }
          }
      }
      public List<int> SavedDiagrams
      {
          get
          {
              return _savedDiagrams;
          }
          set
          {
              if (_savedDiagrams != value)
              {
                  _savedDiagrams = value;
                  NotifyChanged("SavedDiagrams");
              }
          }
      }
      public int? SavedDiagramId
      {
          get
          {
              return _savedDiagramId;
          }
          set
          {
              if (_savedDiagramId != value)
              {
                  _savedDiagramId = value;
                  NotifyChanged("SavedDiagramId");
              }
          }
      }
      #endregion

      #region Commands
      private ICommand _deleteSelectedItemsCommand;
      public ICommand DeleteSelectedItemsCommand
      {
          get
          {
              if(_deleteSelectedItemsCommand == null)
              {
                  _deleteSelectedItemsCommand = new DelegateCommand(DeleteSelectedItems);
              }
              return _deleteSelectedItemsCommand;
          }
      }

      private ICommand _createNewDiagramCommand;
      public ICommand CreateNewDiagramCommand
      {
          get
          {
              if (_createNewDiagramCommand == null)
              {
                  _createNewDiagramCommand = new DelegateCommand(CreateNewDiagram);
              }
              return _createNewDiagramCommand;
          }
      }
      private ICommand _saveDiagramCommand;
      public ICommand SaveDiagramCommand
      {
          get
          {
              if (_saveDiagramCommand == null)
              {
                  _saveDiagramCommand = new DelegateCommand(SaveDiagram);
              }
              return _saveDiagramCommand;
          }
      }
      private ICommand _loadDiagramCommand;
      public ICommand LoadDiagramCommand
      {
          get
          {
              if (_loadDiagramCommand == null)
              {
                  _loadDiagramCommand = new DelegateCommand(LoadDiagram);
              }
              return _loadDiagramCommand;
          }
      }

      
      #endregion

      #region Command Execute Method
      private void DeleteSelectedItems(object obj)
      {
          throw new NotImplementedException();
      }
      private void CreateNewDiagram(object obj)
      {
          throw new NotImplementedException();
      }
      private void SaveDiagram(object obj)
      {
          throw new NotImplementedException();
      }
      private void LoadDiagram(object obj)
      {
          throw new NotImplementedException();
      }
      #endregion
      public WindowViewModel()
      {
          DiagramViewModel = new DiagramViewModel();
      }
    }
}
