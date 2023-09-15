using System;

class Prim
{
    const int V = 5;
    const int INF = 9999999;

    static void Main()
    {
        int noEdge = 0;
        bool[] selected = new bool[V];
        Array.Fill(selected, false);
        noEdge = 0;
        selected[0] = true;
        int x = 0;
        int y = 0;
        Console.WriteLine("Edge : Weight");

        while (noEdge < V - 1)
        {
            int min = INF;
            x = 0;
            y = 0;

            for (int i = 0; i < V; i++)
            {
                if (selected[i])
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (!selected[j] && G[i, j] > 0)
                        {
                            if (min > G[i, j])
                            {
                                min = G[i, j];
                                x = i;
                                y = j;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{x} - {y} : {G[x, y]}");
            selected[y] = true;
            noEdge++;
        }
    }

    static int[,] G = {
        {0, 9, 75, 0, 0},
        {9, 0, 95, 19, 42},
        {75, 95, 0, 51, 66},
        {0, 19, 51, 0, 31},
        {0, 42, 66, 31, 0}
    };
}
