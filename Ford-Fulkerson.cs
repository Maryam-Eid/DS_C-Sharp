using System;
using System.Collections.Generic;

class FordFulkerson
{
    private int V;

    public FordFulkerson(int v)
    {
        V = v;
    }

    private bool BreadthFirstSearch(int[,] graph, int s, int t, int[] parent)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(s);
        visited[s] = true;
        parent[s] = -1;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && graph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }
        return visited[t];
    }

    public int MaxFlow(int[,] graph, int source, int sink)
    {
        int[] parent = new int[V];
        int maxFlow = 0;

        while (BreadthFirstSearch(graph, source, sink, parent))
        {
            int pathFlow = int.MaxValue;
            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                pathFlow = Math.Min(pathFlow, graph[u, v]);
            }

            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                graph[u, v] -= pathFlow;
                graph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }
        return maxFlow;
    }

    public static void Main()
    {
        int[,] graph = {
            {0, 8, 0, 0, 3, 0},
             {0, 0, 9, 0, 0, 0},
             {0, 0, 0, 0, 7, 2},
             {0, 0, 0, 0, 0, 5},
             {0, 0, 7, 4, 0, 0},
             {0, 0, 0, 0, 0, 0}
            
        };

        FordFulkerson fordFulkerson = new FordFulkerson(6);

        int source = 0;
        int sink = 5;

        int maxFlow = fordFulkerson.MaxFlow(graph, source, sink);
        Console.WriteLine("Max Flow from source to sink: " + maxFlow);
    }
}
