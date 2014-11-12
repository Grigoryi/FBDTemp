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
        public MainWindow()
        {
            InitializeComponent();
            //BaseAlgoritm a = new BaseAlgoritm();
            //if (a is IAlgoritmModel) MessageBox.Show("Yes");
            //MessageBox.Show(a.GetType().ToString());
            
          //  Type _typeOutput; ;
         //   MessageBox.Show(_typeOutput.ToString());
           // double d;
            SumAlgoritm sa = new SumAlgoritm(typeof(double));
            sa.Run();
            SimpleBaseViewModel sbvm = new SimpleBaseViewModel(sa,new Guid());
            //MessageBox.Show(sa.Outputs[0].Output.ToString());
            BaseBlockView bbv = new BaseBlockView();
            bbv.DataContext = sbvm;
            Grid1.Children.Add(bbv);
            
        }
    }
}
