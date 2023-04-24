using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    // 이진 트리의 경우 굳이 노드형식의 데이터를 사용하지않고
    // 트리에서부터 루트 1 왼쪼리프2 오른쪽리프3 등 배열기반으로 설계가 가능함.
    // 완전이진트리(요소가 비어있지 않은)의 경우 왼 : 부모의 index*2+1 오:index*2+2 부모를호출 -> : (자식-1)/2

    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;
            public int priority;
            //public TPriority priority;
        }

        private List<Node> nodes;
        //private IComparer<TPriority> comparer;

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
            //this.comparer = Comparer<TPriority>.Default;          //C#의 비교연산자
        }

        /*public PriorityQueue()       // 오버로딩 IComparer<TPriority> comparer
        {
            this.nodes = new List<Node>();
            //this.comparer = comparer;
        }*/


        public int Count { get { return this.nodes.Count; } }

        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };

            //1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;

            // 2.  새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while(newNodeIndex> 0)
            {
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                // 2-2 자식 노드가 부모 노드보다 우선수위가 높으면 교체
                if (newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 1. 가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            // 2. 자식노드들과 비교하여 더작은 자식과 교체 반복
            while(index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GEtRightChildIndex(index);

                // 2-1 자식이 둘다있는 경우
                if (rightChildIndex < nodes.Count)
                {
                    // 2-1-1. 왼쪽자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority
                        ? leftChildIndex : rightChildIndex;
                    // 2-1-2. 더 우선순위가 높은 자식과 부모 노드를 비교하여 바꿈
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }

                }
                // 2-2 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2-3 자식이 없는 경우
                else
                {
                    break;
                }
            }
            
            
            return rootNode.element;
        }

        public TElement Peek()
        {
            return nodes[0].element;
        }
        private int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }          // 부모 인덱스 구하는 함수.
        private int GetLeftChildIndex(int parentIndex) { return parentIndex * 2 + 1; }
        private int GEtRightChildIndex(int parentIndex) { return parentIndex * 2 + 2; } 
    }
}
