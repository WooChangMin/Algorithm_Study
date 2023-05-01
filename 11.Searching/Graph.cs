using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Searching
{
    internal class Graph
    {
        /******************************************************
         * 그래프 (Graph)
         * 
         * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐 -> 트리와 다른점(갔던길은 다시쓰지않고 자신의 정점을 돌아올경우 순환구조로 침.)
         * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
         * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
         ******************************************************/
        // 게임개발에선 경로탐색 길찾기등 사용

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 사용하여 표현 시도 [a,b] -> 시작정점:a  끝정점 : b
        // 장점 : 인접 여부 접근이 빠름  
        // 단점 : 간선의 수에 상관없이 모든 경우의수의 저장이 필요하므로 최적의 경우에도 메모리사용량이 많음.
        bool[,] matrixGraph1 = new bool[5, 5]
        {   //[0,0] [0,1] [0,2] [0,3] [0,4]   양방향의경우 왼쪽위에서 시작하는 대각선을 기준으로 대칭
            {false, true, true, true, true },
            {true, false, true,false, true },
            {true, true, false,false, false },
            {true, false,false,false, true },
            {true, true, false,true, false }
        };

        const int INF = int.MaxValue;
        int[,] matrixGraph2 = new int[5, 5]
        {
            {0, 132, 110, 16, INF},
            {0, 132, 110, 16, INF},
            {0, 132, 110, 16, INF},
            {0, 132, 110, 16, INF},
            {0, 132, 110, 16, INF}
        };
        // 단절된경우 음수로 표현하는거보다 무한으로 표현하는것이 설계상 적합한경우가 많음.


        // <인접리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리사용량이 적다
        // 딘점 : 인접 여부를 확인하기위해 리스트 탐색이 필요
        List<List<int>> listGraph1;            //연결그래프
        List<List<(int, int)>> listGraph2;    //가중치그래프
        public void CreateGraph()
        {
            listGraph1 = new List<List<int>>();
            for(int i = 0; i <5 ; i++)
            {
                listGraph1.Add(new List<int>());
            }
            listGraph1[0].Add(1);
            listGraph1[1].Add(0);
            listGraph1[1].Add(3);
        }
    
    }
}
