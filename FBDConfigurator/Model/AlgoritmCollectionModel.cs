using FBDConfigurator.Controls;
using FBDConfigurator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDConfigurator.Model
{
  public class AlgoritmCollectionModel: Module
    {
      public AlgoritmCollectionModel()
      {
          ViewModel = new AlgoritmsCollectionViewModel();
      }
    }
}
