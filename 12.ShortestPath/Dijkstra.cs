﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ShortestPath
{
    internal class Dijkstra
    {
		/******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/
		// 직접가는 거리보다 거쳐서 가는게 짧을경우 직접가는거리를 교체해버림
		// 거쳐가는 가중치가 낮은거부터 확인을 한다.

		const int INF = 99999;
		// 비교를할때 덧셈을 할경우 MaxValue를 사용하면 오버플로우 발생 가능성
		public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
		{
			int size = graph.GetLength(0);
			bool[] visited = new bool[size];

			distance = new int[size];
			path = new int[size];
			for (int i = 0; i< size; i++)
			{
				distance[i] = graph[start, i];
				path[i] = graph[start,i] < INF ? start : -1;
			}

			for (int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int next = -1;
				int minCost = INF;
				for(int j =0; j < size; j++)
				{
					if (!visited[j] &&
						distance[j] < minCost)
					{
						next = j;
						minCost = distance[j];
					}
				}

				// 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신
				for (int j =  0; j <size; j++)
				{
					// distance[j] => 목적지까지 직접 연결된 거리
					// distance[next] => 탐색중인 정점까지의 거리
					// graph[next, j] => 탐색중인 정점에서 목적지까지의 거리
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
