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
       void Reset();
       //Визуальное отображение на блоке
       object VisualContent { get; }
       string AlgoritmName { get;}
       SettingCollection Parametrs { get; set; }
       
      // IBlockModel Block { get; set; }
      // void UpdateAlgoritm(IAlgoritmModel algoritm);


       event EventHandler<AlgoritmEventArgs> AlgoritmUpdated;
       event EventHandler AlgoritmCalculated;
    }
}
