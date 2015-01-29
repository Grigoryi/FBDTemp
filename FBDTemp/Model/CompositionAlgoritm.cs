using FBDTemp.Model.Algoritms;
using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public class CompositionAlgoritm: ResizableAlgoritm
    {
      private ITopologicalSort _sort;

      private List<Node> _graph;

      public List<Node> Graph 
      { get { return _graph; } }

      private bool isReady;

      int maxId = 0;

      
      public CompositionAlgoritm() 
      {
          _graph = new List<Node>();
          _sort = new DemucronSort();
          isReady = false;

          MinCountInput = MinCountOutput = 0;
          MaxCountInput = MaxCountOutput = int.MaxValue;

          _outputs = new List<Algoritms.SimpleInputAlgoritm>();
          _inputs = new List<Algoritms.SimpleOutputAlgoritm>();

          Parametrs = new SettingCollection(this);

      }

      public override void Run()
      {
          if(!isReady)
          {
              _sort.Sort(Graph);
              foreach (Node n in Graph)
                  if (n.Algoritm is SimpleInputAlgoritm) n.Level = 0;
              isReady = true;
          }

          for (double i = 0; i < 10; i += 0.1)
              for (int j = 0; j < Graph.Count; j++) //кол-во итераций равно кол-ву элементов(что не оптималбьно). Надо переписать
                  foreach (Node n in Graph)
                      if (n.Level == j) n.Algoritm.Run();

                  base.Run();
      }


      public void AddNode(IAlgoritmModel algoritm)
      {
          maxId++;
          Graph.Add(new Node(maxId, algoritm));
      }
      public void RemoveNode(int id)
      {
        int pos = -1;
          for(int i = 0; i < Graph.Count; i++)
             if (Graph[i].ID == id) pos = i;

          if(pos > -1)
          Graph.RemoveAt(pos);
      }
      public void AddEdge(int IdFrom, int IdTo)
      {
          isReady = false;
      }
      public void RemoveEdge(int IdFrom, int IdTo)
      {
          isReady = false;
      }
      
      
    }
}
