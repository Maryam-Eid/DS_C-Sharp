using System;
using System.Collections.Generic;
using System.Linq;

class Graph
{
    private List<Tuple<int, Tuple<int, int>>> G; 
    private List<Tuple<int, Tuple<int, int>>> T; 
    private int[] parent;
    private int V;
    
    public Graph(int V)
    {
        parent = new int[V];

        for (int i = 0; i < V; i++)
            parent[i] = i;

        G = new List<Tuple<int, Tuple<int, int>>>();
        T = new List<Tuple<int, Tuple<int, int>>>();
    }

    public void AddWeightedEdge(int u, int v, int w)
    {
        G.Add(new Tuple<int, Tuple<int, int>>(w, new Tuple<int, int>(u, v)));
    }

    public int FindSet(int i)
    {
        if (i == parent[i])
            return i;
        else
            return FindSet(parent[i]);
    }

    public void UnionSet(int u, int v)
    {
        parent[u] = parent[v];
    }

    public void Kruskal()
    {
        int uRep, vRep;
        G = G.OrderBy(x => x.Item1).ToList();

        for (int i = 0; i < G.Count; i++)
        {
            uRep = FindSet(G[i].Item2.Item1);
            vRep = FindSet(G[i].Item2.Item2);

            if (uRep != vRep)
            {
                T.Add(G[i]);
                UnionSet(uRep, vRep);
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("Edge : Weight");
        for (int i = 0; i < T.Count; i++)
        {
            Console.WriteLine($"{T[i].Item2.Item1} - {T[i].Item2.Item2} : {T[i].Item1}");
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(6);
        g.AddWeightedEdge(0, 1, 4);
        g.AddWeightedEdge(0, 2, 4);
        g.AddWeightedEdge(1, 2, 2);
        g.AddWeightedEdge(1, 0, 4);
        g.AddWeightedEdge(2, 0, 4);
        g.AddWeightedEdge(2, 1, 2);
        g.AddWeightedEdge(2, 3, 3);
        g.AddWeightedEdge(2, 5, 2);
        g.AddWeightedEdge(2, 4, 4);
        g.AddWeightedEdge(3, 2, 3);
        g.AddWeightedEdge(3, 4, 3);
        g.AddWeightedEdge(4, 2, 4);
        g.AddWeightedEdge(4, 3, 3);
        g.AddWeightedEdge(5, 2, 2);
        g.AddWeightedEdge(5, 4, 3);
        g.Kruskal();
        g.Print();
    }
}
