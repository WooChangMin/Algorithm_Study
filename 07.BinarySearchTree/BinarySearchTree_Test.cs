using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
    internal class BinarySearchTree_Test<T> where T: IComparable<T>
    {
        private Node root;

        public BinarySearchTree_Test()                                               // 이진탐색트리 생성자.
        {
            this.root = null;
        }

        public void Add(T item)                                                      // 노드추가 T item 을 받음.
        {
            Node newNode = new Node(item, null, null, null);                         // 새로운 노드를만들고 item을넣어주고 연결노드는 null로 초기화시켜줌
            if (root == null)                                                        // rootNode가 없을경우 새로운 노드를 루트로 만들어주면됨.
            {
                root = newNode;
                return;
            }
            Node current = root;                                                     // 그게아닌경우 current라는 새로운 노드에 root를 넣어줌
            while (current != null)                                                  // 현재 current가 null 이아닐때까지 반복 -> 널인경우는 없음. 그러므로 계속 반복
            {
                if (item.CompareTo(current.item) > 0)                                // CompareTo함수를 사용하여 뉴노드의 item이 current의 item보다 큰경우 양수임.
                {
                    if (current.right == null)                                       // 오른쪽으로 내려가야하는데 현재노드의 오른쪽 값이없으면 추가해주면됨. parent노드와의 연결또한추가
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        break;                                                       // 이후while문 종료를위한 break;
                    }
                    else if (current.right != null)                                  // 오른쪽 요소가 있었을경우 current의 위치를 right로 옮겨주고 다시반복
                    {
                        current = current.right;
                    }
                }
                else if (item.CompareTo(current.item) < 0)                           // item이 음수인경우 current값보다 작음.
                {
                    if(current.left == null)                                         // 이경우 left에 노드가 없으면 추가해주면되고 break
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        break;
                    }
                    else if(current.left != null)                                    //값이 있었을경우 current의 위치를 옮겨주고 다시함수실행
                    {
                        current = current.left;
                    }
                }
                else                                                                // 아이템두개를 비교했을때 같지도 작지도않다면 같은값이들어온경우. 아무행동도취하지한고 리턴 ->함수종료
                {
                    return;
                }
            }
        }
        
        public bool Remove(T item)                                                  // findNode와 Erase노드를 사용하여 Remove구현
        {
            Node findNode = FindNode(item);                                         //FindNode의 값이 있을때 없을떄의 조건부 추가.

            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }

        private Node FindNode(T item)                                                // 특정item값이 주어졌을때 해당 item을 가지고있는 노드 반환
        {
            if (root == null)                                                       // root가 null일경우 뺼값이없음.
            {
                return null;
            }
            Node node = root;                                                       // 새로운탐색노드를 node로 새로만듬.
            while (node != null)                                                    // node가 null이아닐때까지 반복.
            {
                if (item.CompareTo(node.item) > 0)                                  // 노드의 아이템과 아이템의 값을 비교해가면서내려감
                {
                    node = node.right;                                              // 해당값이 양수일경우 item이 더큰것이므로 노드의 오른쪽으로이동
                }
                else if (item.CompareTo(node.item) < 0)                             // 음수일경우 item이더작으므로 노드의 왼쪽으로 이동
                {
                    node = node.left;
                }
                return node;                                                        // 어느 if문에도 걸리지않을경우 찾은것이므로 return
            }
            return null;                                                            // node가 쭉내려가다가 null이 되어버린시점에서 node를 반환
        }
        private void EraseNode(Node node)                                           //특정 노드를 지우는 함수 노드를 입력받는다. 이 노드는 차후 findNode에서 반환형식으로 사용
        {
            if (node.HasNot)                                                        // 노드에게 자식이 아무도 없을경우에 
            {
                if (node.IsLeftChild)                                               // 노드가 왼쪽노드였다면, 부모의 왼쪽값을 null 로
                {
                    node.parent.left = null;                                        
                }
                else if (node.IsRightChild)                                         // 오른쪽 노드였다면, 부모의 오른쪽값을 null
                {
                    node.parent.right = null;
                }
                else                                                                // 부모가 없었다면.? 루트였으므로 루트를 null로 만들어준다 ->자식도 없기때문
                    root = null;
            }
            else if (node.HasOnlyLeft || node.HasOnlyRight)                         // 지워야하는 노드에게 자식이 한개있는경우
            {
                Node parent = node.parent;                                          // 보기 쉽게 노드의 부모값을 parent에 대입
                Node child = node.HasOnlyLeft ? parent.left : parent.right;         // 왼쪽만 있는경우도있고 오른쪽만 있는경우도 있으므로 삼중구문을 사용해서
                                                                                    // HasOnlyLeft가 트루일경우 parent.left를 false일경우 parent.right를 가리키게 만듬.
                if (node.IsLeftChild)                                               // 노드가 왼쪽 자식이었을경우 부모의 왼쪽값과 child값을 이어줌
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)                                         // 노드가 오른쪽 자식이었을 경우에도 동일
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else                                                                // 노드가 자식이아니다 ? => 루트인경우
                {
                    root = child;                                                   // 루트값에 자식을넣어주고 자식의 부모는 없음.
                    child.parent = null;
                }
            }
            else                                                                    // 마지막으로 노드가 자식이 둘이었을경우
            {                                                                       // C#에서는 왼쪽노드로 가서 가장오른쪽값을 대체하는 방식 사용
                Node replaceNode = node.left;                                       // 대체할노드를 노드의 왼쪽값을 넣어줌
                while(replaceNode.right != null)                                    // 해당노드의 오른족값이 null이 아닐때까지
                {
                    replaceNode = replaceNode.right;                                // 노드를 계속 오른쪽값으로 대체함 -> 결국 가장오른쪽값을 가리키게됨
                }
                node.item = replaceNode.item;                                       // 이후해당노드의 item을 노드에넣어주고
                EraseNode(replaceNode);                                             // 해당노드의 삭제 진행
            }
        }


        class Node                                                                   //노드형 기반으로 만들어져있으므로 class기반의 노드를 만듬
        {
            internal T item;                                                         //해당노드는 담고있는 값이있고
            internal Node parent;                                                    // 부모와 각각자식노드의 정보를 가지고있음
            internal Node left;
            internal Node right;

            public Node(T item, Node parent, Node left, Node right)                  // Class 구조의 생성자.
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRoot { get { return parent == null; } }                    //현재 자신의 상태 판별 부모노드가 없으면 루트
            public bool IsRightChild { get { return parent != null && parent.right == this; } } //부모노드가있고 부모의 right가 자신이면 right
            public bool IsLeftChild { get { return parent != null && parent.left == this; } } //부모노드가있고 부모의 left가 자신이면 left



            public bool HasOnlyLeft {get { return left != null && right == null; } }     // 해당노드들이 자식들을 갖고있는 유형을 정의함.
            public bool HasOnlyRight {get { return left == null && right != null; } }    // bool값으로 반환받음 (이후 if문내에서 사용)
            public bool HasBoth {get { return left != null && right != null; } }
            public bool HasNot{get { return left == null && right == null; } }
        }
    }
}
