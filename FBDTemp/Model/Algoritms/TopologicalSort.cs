using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model.Algoritms
{
   
    /// <summary>
    /// Топологическая сортировка, осуществляемая методом обхода в глубину
    /// </summary>
   public class DepthFirstSearchSort : ITopologicalSort
    {

        public void Sort( List<Node> graph)
        {
            foreach (Node n in graph)
                n.Level = -1;


        }

        public int[] SortToArray( List<Node> graph)
        {
            foreach (Node n in graph)
                n.Level = -1;


            int[] array = new int[graph.Count];
            for (int i = 0; i < graph.Count; i++)
                array[i] = graph[i].Level;

            return array;
        }
    }
    /// <summary>
    /// Топологическая сортиовка методом Демукрона, путем постепенного исключения вершин
    /// </summary>
    public class DemucronSort : ITopologicalSort
    {

        public void Sort( List<Node> graph)
        {
            foreach (Node n in graph)
                n.Level = -1;
            int?[] workArray = GetInputNodesArray(graph);

            int completedCounter = 0;
            int currentLevel = 0;



            while (completedCounter != graph.Count)
            {
                for (int i = 0; i < graph.Count; i++)
                {
                    if (workArray[i] == 0) workArray[i] = null;
                }
                for (int i = 0; i < graph.Count; i++)
                {
                    if (workArray[i] == null)
                    {
                        graph[i].Level = currentLevel;
                        foreach (Node n in graph[i].NextNodes)
                        {
                            int childrenNode = graph.IndexOf(n);
                            workArray[childrenNode]--;
                        }
                        workArray[i] = -1;
                        completedCounter++;
                    }
                }
                currentLevel++;
                ///нужно добавить проверку на петлю
            }
        }

        public int[] SortToArray( List<Node> graph)
        {
            foreach (Node n in graph)
                n.Level = -1;

            BaseSort(graph);
            

            int[] array = new int[graph.Count];
            for (int i = 0; i < graph.Count; i++)
                array[i] = graph[i].Level;

            return array;
        }
        private void BaseSort( List<Node> graph)
        {
            // int[,] levels = new int[graph.Count,graph.Count];
             int?[] workArray = GetInputNodesArray(graph);

             int completedCounter = 0;
             int currentLevel = 0;

             

            while(completedCounter != graph.Count)
            {
                for(int i = 0; i < graph.Count; i++)
                {
                    if (workArray[i] == 0) workArray[i] = null;
                }
                for(int i = 0; i < graph.Count; i++)
                {
                    if(workArray[i] == null)
                    {
                        graph[i].Level = currentLevel;
                        foreach(Node n in graph[i].NextNodes)
                        {
                            int childrenNode = graph.IndexOf(n);
                            workArray[childrenNode]--;
                        }
                        workArray[i] = - 1;
                        completedCounter++;
                    }
                }
                currentLevel++;
                ///нужно добавить проверку на петлю
            }
        }

        private int?[] GetInputNodesArray(List<Node> graph)///записывает в массив количество входящих в вершину дуг
        {
            int?[] array = new int?[graph.Count];
            for (int i = 0; i < graph.Count; i++)
                array[i] = graph[i].NextNodes.Count;

            return array;
        }

    }
}
