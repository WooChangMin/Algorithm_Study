using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _12.ShortestPath
{
    internal class Dijkstra_Test
    {
        const int INF = 99999;
        
        public static void ShortestPath(in int[,] graph, in int start, out int[] distance , out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];

            for(int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
            }

            for (int i = 0; i < size; i++)
            {
                int next = -1;
                int minCost = INF;
                // 가장 작은 가중치
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minCost)
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }
                if (next < 0)
                    break;

                for(int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
