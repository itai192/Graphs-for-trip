using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Graphs
{
    public class Graph
    {
        private bool[,] graph;
        public static int counter = 0;

        public static bool RemoveEdgesFromGraphAndCheck(Graph graph, int order, int vertex, int amount, int iteration)
        {
            if (order == amount)
            {
                if (graph.GetVertecies() - 1 == vertex)
                {
                    return graph.IsConnected();
                }
                else
                {
                    return Remove(graph, order, vertex + 1, 0, 0);
                }
            }
            if (graph.GetVertecies() - iteration < order - amount)
            {
                return true;
            }
            if (graph.IsEdge(vertex, iteration))
            {
                graph.RemoveEdge(vertex, iteration);
                if (!RemoveEdgesFromGraphAndCheck(graph, order, vertex, amount + 1, iteration + 1))
                {
                    graph.AddEdge(vertex, iteration);
                    return false;
                }
                else
                {
                    graph.AddEdge(vertex, iteration);
                }
            }
            if (!RemoveEdgesFromGraphAndCheck(graph, order, vertex, amount, iteration + 1))
                return false;
            return true;
        }
        public static bool RemoveEdgesFromGraphAndCheck(Graph graph, int order)
        {
            return RemoveEdgesFromGraphAndCheck(graph, order, 0, 0, 0);
        }
        public static bool CheckGraph(Graph g)
        {
            if (RemoveEdgesFromGraphAndCheck(g, 2))
            {
                g.Print();
                for (int i = 0; i < 5 * 12; i++)
                {
                    Console.Write("#");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                return false;
            }
            counter++;
            if (counter % 100000000 == 0)
                Console.WriteLine(counter);
            return false;
        }
        public bool IsEdge(int from, int to)
        {
            return graph[from, to];
        }
        public Graph(Graph g)
        {
            this.graph = (bool[,])g.graph.Clone();
        }
        public void Print()
        {
            for(int i = 0;i<graph.GetLength(0);i++)
            {
                for (int j = 0; j < graph.GetLength(1);j++)
                {
                    Console.Write(graph[i, j].ToString().PadLeft(5) + " ");
                }
                Console.WriteLine("");
            }
        }
        public Graph(int verticies)
        {
            graph = new bool[verticies,verticies];
            for(int i = 0;i<graph.GetLength(0); i++)
            {
                for(int j=0;j<graph.GetLength(1); j++)
                {
                    graph[i, j] = false;
                }
            }
        }
        public void AddEdge(int from, int to)
        {
            graph[from, to] = true;
        }

        public void RemoveEdge(int from, int to)
        {
            graph[from, to] = false;
        }
        public bool IsPathExist(int from, int to, List<int> path)
        {
            path.Add(from);
            for(int i = 0; i< graph.GetLength(1); i++)
            {
                if(graph[from,i]&&!path.Contains(i))
                    if (IsPathExist(i, to, path))
                        return true;
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[i, from]&& !path.Contains(i))
                    if (IsPathExist(i, to, path))
                        return true;
            }
            path.Remove(from);
            return false;
        }
        public bool IsConnected()
        {
            for(int i = 1;i<graph.GetLength(0);i++)
            {
                if (!IsPathExist(0, i))
                    return false;
            }
            return true;
        }
        public bool IsPathExist(int from, int to)
        {
            return IsPathExist(from, to, new List<int>());
        }
        
        public static bool CheckAllGraphsOfOrder(int vertecies,int order)
        {
            Graph g = new Graph(vertecies);
            return CheckAllGraphsOfOrder(g, order, 0, 0, 0);
        }
        public int GetVertecies()
        {
            return graph.GetLength(0);
        }
        public static bool CheckAllGraphsOfOrder(Graph graph, int order, int vertex, int amount, int iteration)
        {
            if (order == amount)
            {
                if (graph.GetVertecies() - 1 == vertex)
                {
                    return CheckGraph(graph);
                }
                else
                {
                    return CheckAllGraphsOfOrder(graph, order, vertex + 1, 0, 0);
                }
            }
            if (graph.GetVertecies() - iteration < order - amount)
            {
                return false;
            }
            if (iteration != vertex)
            {
                graph.AddEdge(vertex, iteration);
                if (CheckAllGraphsOfOrder(graph, order, vertex, amount + 1, iteration + 1))
                    return true;
                graph.RemoveEdge(vertex, iteration);
            }
            if (CheckAllGraphsOfOrder(graph, order, vertex, amount, iteration + 1))
                return true;
            return false;
        }
    }
}
