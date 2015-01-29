using FBDConfigurator.Interfaces;
using FBDConfigurator.Metadata;
using FBDConfigurator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FBDConfigurator.Dialogs
{
    /// <summary>
    /// Interaction logic for EditAlgoritmDialog.xaml
    /// </summary>
    public partial class EditAlgoritmDialog : IEditDialog<AlgoritmMetadata>
    {
        public EditAlgoritmDialog()
        {
            InitializeComponent();

            
        }

        private EditDialogViewModel<AlgoritmMetadata> _editDialogViewModel = new EditDialogViewModel<AlgoritmMetadata>();
        public EditDialogViewModel<AlgoritmMetadata> ViewModel
        {
            get
            {
                return _editDialogViewModel;
            }
            set
            {
                if(_editDialogViewModel != value)
                {
                    _editDialogViewModel = value;
                    
                }
            }
        }
        public AlgoritmMetadata Entity
        {
            get { return ViewModel.Entity; }
            set { ViewModel.Entity = value; }
        }
    }
}
