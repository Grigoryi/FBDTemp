using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
   public interface IAlgoritmModel
    {
       //Запускает расчет алгоритма
       void Run();
       //Визуальное отображение на блоке
       object VisualContent { get; }
       string AlgoritmName { get;}
       object Parametrs { get; set; }
       object GetInput();
       object GetOutput();
       IBlockModel Block { get; set; }
      // void UpdateAlgoritm(IAlgoritmModel algoritm);


       event EventHandler<AlgoritmEventArgs> AlgoritmUpdated;
       event EventHandler AlgoritmCalculated;
    }
}
