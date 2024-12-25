using System;
using System.Collections.Generic;

class PrimsAlgorithm
{
    public static void PrimMST(int[,] graph, int verticesCount)
    {
        int[] parent = new int[verticesCount];
        int[] key = new int[verticesCount];
        bool[] mstSet = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0; // Make key 0 for the first vertex
        parent[0] = -1; // The first node is always the root of MST

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinKey(key, mstSet, verticesCount);

            mstSet[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        PrintMST(parent, graph, verticesCount);
    }

    private static int MinKey(int[] key, bool[] mstSet, int verticesCount)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void PrintMST(int[] parent, int[,] graph, int verticesCount)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < verticesCount; i++)
        {
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
        }
    }

    static void Main(string[] args)
    {
        int[,] graph = new int[,]
{
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
};

        int verticesCount = graph.GetLength(0);
        PrimMST(graph, verticesCount);
    }
}
