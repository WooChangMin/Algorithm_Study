using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.PathFInding
{
    internal class Astar
    {
        /******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 ******************************************************/
        // 다익스트라 알고리즘의 경우 특정위치로가야하는 경우에도 모든 방위에대해서 탐색을 하므로 정답은
        // 찾지만 비효율적으로 탐색을 하게된다. 그래서 제안된게 Astar 알고리즘이다.
        // Astar알고리즘의 경우 f, g, h를 알고리즘에 사용한다.
        // f = g + h / 총거리.
        // g = 소모 거리(특정위치까지 도달하기위해 걸린 거리)
        // h(huristic) = 예상거리(중요)
        // f값이 가장작은 정점부터 탐색을해서 탐색한 정점의 f값 구함.
        // 경로의 경우 다익스트라 알고리즘과 동일하게 탐색된 정점의 값을 parent로 가지고 있으면 된다.

        const int CostStraight = 10;
        const int CostDiagnal = 10;

        static Point[] Direction =
        {
            new Point (0, +1),         // 상
            new Point (0, -1),         // 하
            new Point (+1, 0),         // 좌
            new Point (-1, 0),         // 우
            new Point (-1, +1),        // 좌상
            new Point (-1, -1),        // 좌하
            new Point (+1, +1),        // 우상
            new Point (+1, -1),        // 우하
        };

        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path  )
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            bool[,] visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];             // 객체를 넣을수 있는 배열
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>(); // 우리는 f값이 가장작은 정점을 사용할것이므로 우선순위큐를 쓰면 유용하다.

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end) );
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while(nextPointPQ.Count > 0)                            // 우선순위 큐가 빌때까지해줌
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문 표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                
                // 3. 탐색할 정점이 도착지일 경우 도착했다고 판단해서 경로반환
                if(nextNode.point.x == end.x && nextNode.point.x == end.y)         //도착한경우
                {
                    Point? pathPoint = end;
                    path = new List<Point>();
                                                                                   
                    while(pathPoint != null)                                       // 부모정점이 null일때까지 -> 시작지점까지
                    {
                        Point point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;

                    }

                    path.Reverse();                                                 // 도착지점부터 역순으로 추가했으므로 역순으로 해줘야 경로임
                    return true;                                                    // 경로를 찾았으므로 true반환
                }

                // 4. Astar 탐색을 진행
                for(int i = 0; i <Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.x + Direction[i].y;

                    // 4-1 탐색하면 안되는 경우 제외
                    // (1) 맵을 벗어났을때
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;

                    // (2) 장애물 등 맵내에서 갈수 없는 경우
                    else if (tileMap[y, x] == false)
                        continue;

                    // (3) 이미 방문한 정점
                    else if (visited[y, x])
                        continue;

                    // 4.2 탐색  -> f 값을 결정해주는 행위이다.
                    int g = nextNode.g + 10;
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x,y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y,x] == null ||              // 점수계산이 되지않은 정점이거나
                        nodes[y,x].f> newNode.f)           // 가중치가 더낮게 갱신된경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정된다. 
        // 휴리스틱을 전방향으로 1 로설정해주면 AStar알고리즘이 다익스트라 알고리즘이 됨.
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);                  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);                  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해이동하는 거리
            // return CostStraight *(xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        private class ASNode                                        // 정점 -> AStarNode  클래스로 쓴이유 -> 정점들이 빈 경우가 있음. 구조체는 빈값을 가질수가없음
        {                                                    
            public Point point;                                     // 현재 정점 위치
            public Point? parent;                                     // 내 부모가누구인지 누구에 의해서 탐색 당했는지. 출발점의경우 parent좌표가없을수도 있으므로 nullable 사용!
                                                             
            public int f;                                           // f(x) = g(x) + h(x) : 총거리
            public int h;                                           // 예상거리, 목표까지의 추정경로 가중치
            public int g;                                           // 현재까지의 거리, 즉 지금까지거리의 가중치
        
            public ASNode(Point point, Point? parent, int h, int g)   // f 의경우 내가입력해야되는 부분이아니라 g와h로 계산해야되므로 받지않음.
            {
                this.point = point;
                this.parent = parent;
                this.h = h;
                this.g = g;
            }
        }

        public struct Point                                         // 몬스터와 플레이어의 위치 좌표! 구조체
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
