using FBDConfigurator.Helpers;
using FBDConfigurator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FBDConfigurator.ViewModels
{
    public class EditDialogViewModel<T> : ViewModelBase<IEditDialog<T>> where T: class, IDataErrorInfo, INotifyPropertyChanged
    {
        public EditDialogViewModel()
        {
            _okCommand = new DelegateCommand(OkCommandExecuted, OkCommandCanExecute);
            _cancelCommand = new DelegateCommand(CancelCommandExecuted);
        }

        #region Entity

        private T _entity;

        public T Entity
        {
            get { return _entity; }
            set
            {
                UnregisterEntiyPropertyChanged();
                _entity = value;
                NotifyPropertyChanged(this, v => v.Entity);
                _okCommand.RaiseCanExecuteChanged();
                RegisterEntityPropertyChanged();
            }
        }

        private void RegisterEntityPropertyChanged()
        {
            if (_entity != null)
                _entity.PropertyChanged += EntityPropertyChanged;
        }

        private void UnregisterEntiyPropertyChanged()
        {
            if (_entity != null)
                _entity.PropertyChanged -= EntityPropertyChanged;
        }

        private void EntityPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyHelper.GetPropertyName<IDataErrorInfo>(i => i.Error))
                _okCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region OkCommand

        private readonly DelegateCommand _okCommand;

        public ICommand OkCommand { get { return _okCommand; } }

        private bool OkCommandCanExecute(object obj)
        {
            return Entity != null && string.IsNullOrEmpty(Entity.Error);
        }

        private void OkCommandExecuted(object obj)
        {
            UnregisterEntiyPropertyChanged();
            View.DialogResult = true;
        }

        #endregion

        #region CancelCommand

        private readonly ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        private void CancelCommandExecuted(object obj)
        {
            UnregisterEntiyPropertyChanged();
            View.DialogResult = false;
        }

        #endregion
    }
}
