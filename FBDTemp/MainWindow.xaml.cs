using FBDTemp.Model;
using FBDTemp.Model.Algoritms;
using FBDTemp.View;
using FBDTemp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FBDTemp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowViewModel _windowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _windowViewModel = new WindowViewModel();
            this.DataContext = _windowViewModel;
            this.Loaded += MainWindow_Loaded;

           
           // Grid1.Children.Add(bbv);
            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SumAlgoritm sa = new SumAlgoritm(typeof(double));
            sa.Run();
            SimpleBaseViewModel sbvm = new SimpleBaseViewModel(1, _windowViewModel.DiagramViewModel, 15,20,sa);
          
            _windowViewModel.DiagramViewModel.Items.Add(sbvm);

           
            SimpleBaseViewModel sbvm1 = new SimpleBaseViewModel(3, _windowViewModel.DiagramViewModel, 15, 20, sa);

            _windowViewModel.DiagramViewModel.Items.Add(sbvm1);

            SimpleOutputAlgoritm sia = new SimpleOutputAlgoritm(typeof(double));
            SimpleIOBaseViewModel siobvm = new SimpleIOBaseViewModel(2, _windowViewModel.DiagramViewModel, 50, 50, sia);
            _windowViewModel.DiagramViewModel.Items.Add(siobvm);
           
            
        }
    }
}
