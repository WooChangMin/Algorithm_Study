using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
    internal class PriorityQueue_Test<T>
    {
        public struct Node
        {
            public T value;                                             // Node 내의 값과 우선순위를 구조체 변수로 가짐.
            public int prior;
            public Node(T value, int prior)                             // Node 값 초기화 진행
            {
                this.value = value;
                this.prior = prior;
            }
        }
        private List<Node> nodes;

        private int count { get { return this.nodes.Count; } }  

        public PriorityQueue_Test()                                     // 클래스 생성자 만들ㅇ줌
        {
            List<Node> nodes = new List<Node>();
        }

        public void Enqueue(T item, int prior)                          // 우선순위와 값을 넣었을 때 추가하는방법. 
        {
            Node newnode = new Node(item, prior);                       // 새노드를 생성 item 과 prior을가짐 > 구조체초기화
            nodes.Add(newnode);                                         // 노드를 리스트의 맨뒤에 추가
            int newNodeIndex = nodes.Count - 1;                         // 새노드의 인덱스를 지정 크기의 -1

            while (newNodeIndex > 0)                                     // 노드내에 값이있다면 계속 true
            {
                int parentNodeIndex = GetParentNodeIndex(newNodeIndex);  // 부모의 index를 찾아야하므로 함수수행
                Node parentnode = nodes[parentNodeIndex];                // 부모의 노드 변수명을 만들어 parentIndex의 값을 넣음

                if(parentnode.prior > newnode.prior)                     // 부모의 우선수위 가 더큰경우 바꾸어줌
                {
                    nodes[parentNodeIndex] = newnode;
                    nodes[newNodeIndex] = parentnode;
                    newNodeIndex = parentNodeIndex;
                }
                else                                                     //아닌경우 while문을 빠져나오고종료
                {
                    break;
                }
            }
        }

        public T Dequeue()                                            // 노드에서 값을 뽑아내는 방법 > 맨윗값을 뽑아냄
        {
            
            if (nodes.Count == 0)                                        // 노드의 개수가 0이면 빈 리스트이므로 예외상황 발생
                throw new InvalidOperationException();

            Node rootNode = nodes[0];                                    // 맨윗값을 rootNode에 지정하고 꺼내기위해 담아둠 
            Node lastNode = nodes[nodes.Count - 1];                      // 마지막 노드를 새로 만들어줌 이름은 lastNode
            nodes[0] = lastNode;                                         // 마지막 노드를 위의 맨 윗노드로 옮김
            nodes.RemoveAt(nodes.Count - 1);                             // 이후 마지막 노드의 값을 없애고
            int index = 0;                                               // index 값을 0으로 초기화

            while(index < nodes.Count)                                   // index의 값이 노드의 카운트보다 무조건 작으므로 .항상 true
            {
                int leftChildIndex = GetLeftChildIndex(index);           // 왼쪽 자식의 인덱스와 오른쪽 자식의 인덱스를 각각 변수명설정해서 넣어놓음.
                int RightChildIndex = GetRightChildNodeIndex(index);

                if (RightChildIndex<nodes.Count)                         // RightChildINdex값이 존재해서 nodes.Count보다 작을경우 값이두개있는경우
                {
                    int lessChildIndex = nodes[leftChildIndex].prior < nodes[RightChildIndex].prior 
                        ? leftChildIndex : RightChildIndex;              // 왼족과 오른쪽 값의 우선순위를 비교하여 작은쪽의 index를 넣어놓음
                    if (nodes[lessChildIndex].prior < nodes[index].prior)// 현재 노드의 prior값이 둘중 낮은값의 prior값보다 클경우 두 노드의 값을바꾸어줌 
                    {
                        nodes[lessChildIndex] = nodes[index];            // 두 노드의 값을 바꿔주고 인덱스를 교체해줌
                        nodes[index] = nodes[lessChildIndex];
                        index = lessChildIndex;
                    }

                }
                else if(leftChildIndex < nodes.Count)                    // 아닐경우 오른쪽 값이 없다는 거니까 왼쪽만 비교를 해주면 됨.
                {
                    if (nodes[leftChildIndex].prior < nodes[index].prior)// 동일한 행동 반복후 인덱스를 바꿔줌
                    {
                        nodes[leftChildIndex] = nodes[index];
                        nodes[index] = nodes[leftChildIndex]; 
                        index = leftChildIndex;
                    }
                }
                else                                                     // 전부아니라면 break구문으로 while문을 종료해주면됨
                {
                    break;
                }

            }
            return rootNode.value;                                       // Dequeue의 경우 맨윗값을 뽑아내는것이므로 위의 힙상태를 만족시키게 만들어놓은후 rootNode의 값 반환
        }

        public int GetParentNodeIndex(int index)                // 자식의 인덱스가 들어왔을때 부모의 인덱스를 구하는 방법 -> 0.5는 버림
        {
            return (index - 1) / 2;
        }

        public int GetLeftChildIndex(int index)                 // 반대로 부모의 인덱스가들어왔을때 왼쪽 자식의 인덱스를 구하는 방법
        {
            return index * 2 + 1;
        }
        public int GetRightChildNodeIndex(int index)            // 오른쪽 자식의 인덱스 부모의인덱스 *2+2
        {
            return index * 2 + 2;
        }
    }
}
