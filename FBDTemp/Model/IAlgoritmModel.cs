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
       object VisualContent {get;}
       string AlgoritmName { get;}

       event EventHandler AlgoritmCalculated;
    }
}
