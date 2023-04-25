using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>          // 루트에서부터 찾아가려면 비교가 가능해야함..
    {
        private Node root;                                               // 루트노드를 안다면 모든노드를 탐색해 나갈수있다.
        public BinarySearchTree()
        {
            this.root = null;                                            // 처음 생성자의경우 아무것도 없어야함.
        }
        
        public void Add(T item)                                          // 중복허용 여부에따라 추가가 가능한지 불가능한지 bool자료형으로 원래 받음 지금은 void
        {
            Node newNode = new Node(item, null, null, null);             // 넣었을때 노드를 새로생성해줌
            if(root == null)                                             // 루트가 0인경우 -> 아무노드도 없을경우
            {
                root = newNode;
                return;
            }

            Node current = root;                                         // root값을 current에 추가
            while(current != null)
            {
                // 비교해서 더 작은경우 왼쪽으로 감
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교 노드의 왼쪽 자식이 있는경우 
                    if (current.left != null)
                    {
                        //왼쪽 자식과 비교하기위해 옮겨줌
                        current = current.left;
                    }
                    // 비교 노드가 왼쪽자식이 없는경우
                    else
                    {
                        current.left = newNode;                           // 새노드의 위치 정해줌
                        newNode.parent = current;                         // 새 노드의 부모 노드 설정
                        return;                                           // 추가했으므로 함수종료
                    }
                }
                // 비교해서 더 큰 경우 오른쪽으로 감.
                else if (item.CompareTo(current.item) > 0)
                {
                    // 비교노드의 오른쪽 자식이 있는경우
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    // 비교노드의 오른쪽 자식이 없는경우
                    else
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    return;
                }
            }
        }

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

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

        
        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);

            if(FindNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }

        private Node FindNode(T item)
        {
            if (root == null)                                             //루트가 없을경우 뺄값이없음.
                return null;

            Node current = root;
            while(current != null)                                       // current가 null이아닐때까지 무한 반복
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                {
                    //왼쪽 자식부터 다시 찾기.
                    current = current.left;
                }
                // 현재 노드의 값이 찾고자 하는 값보다 큰경우
                else if(item.CompareTo(current.item)  > 0)
                {
                    current = current.right;
                }
                // 현재 노드의 값이 찾고자 하는 값이랑 같은 경우
                else
                {
                    //찾은경우
                    return current;
                }
            }
            return null; 
        }

        private void EraseNode(Node node)
        {
            // 자식이 없는 경우
            if(node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else  // if (node.IsRootNode) => 내가루트인경우
                    root = null;
            }
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else //왼쪽자식도 오른쪽 자식도아닌데 자식을 가진경우 -> 루트노드임.
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 자식 노드가 2개인 노드일 경우
            // 왼쪽 자식중 가장 큰 값과 데이터를 교환한 후, 그 노드를 지워주는 방식으로 대체
            else // if(node.HasBothChild)
            {
                Node replaceNode = node.left;
                while(replaceNode.right != null)
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);
            }
            return;
        }

        public void Print()
        {
            Print(root);
        }

        private void Print(Node node)                                      // 중위순회 구현
        {
            if (node.left != null) Print(node.left);
            Console.WriteLine(node.item);
            if (node.right != null) Print(node.right);
        }

 

        class Node
        {
            internal T item;                                              // 담고있을 데이터 값
            internal Node parent;                                         // 내 부모의 노드값
            internal Node left;                                           // 내 노드의 왼쪽과 오른쪽 노드
            internal Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;  
                this.parent = parent;   
                this.left = left;   
                this.right = right; 
            }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
