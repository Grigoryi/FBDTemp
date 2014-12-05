using FBDTemp.Model;
using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.ViewModel
{
  public class SimpleIOBaseViewModel : DesignerBlockViewModel
    {
      public readonly IIOAlgoritm _model;

      public string Name
      { get { return _model.AlgoritmName; } }

      //private object _value;
      public object Value
      {
          get
          {
             return _model.GetValue();
          }
          set
          {
                 _model.SetValue(value);
                 _model.Run();
           }
          
      }
      //конструктор для создания отдельного блока
      public SimpleIOBaseViewModel(int id, DiagramViewModel parent, double left, double top, IIOAlgoritm algoritm)
      :base(id,parent,left,top)
      {
          _model = algoritm;
         // _model._context.ID = id;
          Value = 5;
           
      }
      //конструктор для создания блока, входящего в состав другого блока
      public SimpleIOBaseViewModel(IIOAlgoritm algoritm, int id)
      {
          _model = algoritm;
          //_model._context.ID = id;
          Value = 0;
      }
    }
}
