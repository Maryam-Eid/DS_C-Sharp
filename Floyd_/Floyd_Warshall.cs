using System;

class FloydWarshallAlgorithm
{
    static readonly int nV = 4;
    static readonly int INF = 999;

    static void Main()
    {
        int[,] graph = {
            {0, 3, INF, 5},
            {2, 0, INF, 4},
            {INF, 1, 0, INF},
            {INF, INF, 2, 0}
        };

        FloydWarshall(graph);
    }

    static void FloydWarshall(int[,] graph)
    {
        int[,] matrix = new int[nV, nV];

        for (int i = 0; i < nV; i++)
        {
            for (int j = 0; j < nV; j++)
            {
                matrix[i, j] = graph[i, j];
            }
        }

        for (int k = 0; k < nV; k++)
        {
            for (int i = 0; i < nV; i++)
            {
                for (int j = 0; j < nV; j++)
                {
                    if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                    {
                        matrix[i, j] = matrix[i, k] + matrix[k, j];
                    }
                }
            }
        }

        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < nV; i++)
        {
            for (int j = 0; j < nV; j++)
            {
                if (matrix[i, j] == INF)
                {
                    Console.Write("INF".PadLeft(4));
                }
                else
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
            }
            Console.WriteLine();
        }
    }
}
