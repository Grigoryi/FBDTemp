using FBDTemp.Model;
using FBDTemp.Model.Algoritms;
using FBDTemp.Services;
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
           // sa.Run();
            SimpleBaseViewModel sbvm = new SimpleBaseViewModel(1, _windowViewModel.DiagramViewModel, 15,20,sa);
           // _windowViewModel.DiagramViewModel.Items.Add(sbvm);
            _windowViewModel.DiagramViewModel.AddItemCommand.Execute(sbvm);
           
           

            SimpleOutputAlgoritm sia = new SimpleOutputAlgoritm();
            SimpleIOBaseViewModel siobvm = new SimpleIOBaseViewModel(2, _windowViewModel.DiagramViewModel, 200, 150, sia);
            
            _windowViewModel.DiagramViewModel.Items.Add(siobvm);

            SimpleInputAlgoritm sia1 = new SimpleInputAlgoritm(); 
            SimpleIOBaseViewModel siobvm2 = new SimpleIOBaseViewModel(3, _windowViewModel.DiagramViewModel, 100, 150, sia1);
            _windowViewModel.DiagramViewModel.Items.Add(siobvm2); sia.SetValue(5);

            ConnectorViewModel con1 = new ConnectorViewModel(siobvm2.connector, siobvm.connector);
            con1.Parent = _windowViewModel.DiagramViewModel;
            _windowViewModel.DiagramViewModel.Items.Add(con1);

          //  SimpleUIVisualizerService suivs = new SimpleUIVisualizerService();
          //  suivs.ShowDialog(sa.Parametrs);
           
        }
    }
}
