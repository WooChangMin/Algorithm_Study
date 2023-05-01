using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Searching
{
    internal class Search
    {
        //어떠한 자료형에도 사용이가능한 기보적인 형태
        // 입력전용 in 파라메터임
        public static int Sequential<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // 탐색의경우 데이터의 정렬이 되어있다고 가정할때, 이진탐색이 가능.
        // <이진탐색>
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) >> 1;
                // 나눗셈은 느리다!  비트연산 사용이 권장
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1;
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;
        }

        // <깊이 우선 탐색 (Depth first search) - DFS
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] path)
        {
            visited = new bool[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                path[i] = -1;
            }
            SearchNode(graph, start, visited, path);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] &&                  // 연결된적이 없는 정점이며
                    !visited[i])                         // 방문한적이 없는 정점
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }

        // <너비 우선 탐색 (Breadth first search )>BFS
        // 그래프의 분기를 만났을 때 모든 분기를 하나씩 저장하고,
        // 저장한 분기를 한번씩 거치면서 탐색
        // 큐로 구현이가능하다.
        public static void BFS(bool[,] graph, int start, out bool[] visited , out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i<graph.GetLength(0); i++)
                {
                    if (graph[start, i] &&                  // 연결된적이 없는 정점이며
                   !visited[i])                         // 방문한적이 없는 정점
                    {
                        parents[i] = start;
                        SearchNode(graph, i, visited, parents);
                    }
                }
            }
        }



    }
}
