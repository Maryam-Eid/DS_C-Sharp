using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        DijkstrasTest();
    }

    static List<Node> nodes = new List<Node>();
    static List<Edge> edges = new List<Edge>();

    class Node
    {
        public char Id { get; }
        public Node Previous { get; set; }
        public int DistanceFromStart { get; set; }

        public Node(char id)
        {
            Id = id;
            Previous = null;
            DistanceFromStart = int.MaxValue;
            nodes.Add(this);
        }
    }

    class Edge
    {
        public Node Node1 { get; }
        public Node Node2 { get; }
        public int Distance { get; }

        public Edge(Node node1, Node node2, int distance)
        {
            Node1 = node1;
            Node2 = node2;
            Distance = distance;
            edges.Add(this);
        }

        public bool Connects(Node node1, Node node2)
        {
            return (Node1 == node1 && Node2 == node2) || (Node1 == node2 && Node2 == node1);
        }
    }

    static void DijkstrasTest()
    {
        Node a = new Node('a');
        Node b = new Node('b');
        Node c = new Node('c');
        Node d = new Node('d');
        Node e = new Node('e');
        Node f = new Node('f');
        Node g = new Node('g');

        new Edge(a, c, 1);
        new Edge(a, d, 2);
        new Edge(b, c, 2);
        new Edge(c, d, 1);
        new Edge(b, f, 3);
        new Edge(c, e, 3);
        new Edge(e, f, 2);
        new Edge(d, g, 1);
        new Edge(g, f, 1);

        a.DistanceFromStart = 0;
        Dijkstras();
        PrintShortestRouteTo(f);
    }

    static void Dijkstras()
    {
        while (nodes.Count > 0)
        {
            Node smallest = ExtractSmallest(nodes);
            List<Node> adjacentNodes = AdjacentRemainingNodes(smallest);

            foreach (Node adjacent in adjacentNodes)
            {
                int distance = Distance(smallest, adjacent) + smallest.DistanceFromStart;

                if (distance < adjacent.DistanceFromStart)
                {
                    adjacent.DistanceFromStart = distance;
                    adjacent.Previous = smallest;
                }
            }
        }
    }

    static Node ExtractSmallest(List<Node> nodes)
    {
        int size = nodes.Count;
        if (size == 0)
            return null;
        int smallestPosition = 0;
        Node smallest = nodes[0];
        for (int i = 1; i < size; ++i)
        {
            Node current = nodes[i];
            if (current.DistanceFromStart < smallest.DistanceFromStart)
            {
                smallest = current;
                smallestPosition = i;
            }
        }
        nodes.RemoveAt(smallestPosition);
        return smallest;
    }

    static List<Node> AdjacentRemainingNodes(Node node)
    {
        List<Node> adjacentNodes = new List<Node>();
        foreach (Edge edge in edges)
        {
            Node adjacent = null;
            if (edge.Node1 == node)
            {
                adjacent = edge.Node2;
            }
            else if (edge.Node2 == node)
            {
                adjacent = edge.Node1;
            }
            if (adjacent != null && nodes.Contains(adjacent))
            {
                adjacentNodes.Add(adjacent);
            }
        }
        return adjacentNodes;
    }

    static int Distance(Node node1, Node node2)
    {
        foreach (Edge edge in edges)
        {
            if (edge.Connects(node1, node2))
            {
                return edge.Distance;
            }
        }
        return -1;
    }

    static bool Contains(List<Node> nodes, Node node)
    {
        return nodes.Contains(node);
    }

    static void PrintShortestRouteTo(Node destination)
    {
        Node previous = destination;
        Console.WriteLine("Distance from start: " + destination.DistanceFromStart);
        while (previous != null)
        {
            Console.Write(previous.Id + " ");
            previous = previous.Previous;
        }
        Console.WriteLine();
    }
}
