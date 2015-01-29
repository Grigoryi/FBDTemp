using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Interfaces
{
   public interface ITopologicalSort
    {
       void Sort(List<Node> graph);
       int[] SortToArray(List<Node> graph);
    }

    public class Node
    {
        public int ID { get; set; }
        public int Level { get; set; }
        public IAlgoritmModel Algoritm {get; set;}
        public List<Node> NextNodes { get; set; }
        public List<Node> PreviusNodes { get; set; }

        public Node(int id, IAlgoritmModel algoritm)
        {
            this.ID = id;
            this.Algoritm = algoritm;
            this.Level = -1;
        }
    }
}
