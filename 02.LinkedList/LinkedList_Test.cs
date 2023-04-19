using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _Datastructure
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int count;

        public LinkedList()
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
        }

        public void AddFirst(T value)                                             // 노드에 추가될 자료형 T의 value값을 받아야함
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);       //추가될 새 노드 생성해주기 추가할떄 리스트는 this로 받음
            
            if (this == null)                                                     //list가 null 일경우
            {
                head = newNode;                                                   // newNode가 헤드이자 테일이됨
                tail = newNode;
            }
            else                                                                  // 아닐경우 노드의 순서변경
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            count++;
        }
        
        public void AddLast(T value)                                              // AddFirst와 유사하게 구현
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> (this, value);      //
            
            if(this == null)                                                      // list가 null 일경우
            {
                head = newNode;                                                   // newNode 하나밖에 없는 헤드이자 테일
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            count++;
        }
        

        public void AddBefore (LinkedListNode<T> node, T value)                   //AddBefore구현 뒤로갈 노드와 새로운 노드에 들어갈 값이 필요함
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);       // 새노드를 만들어주고 이름 newnode

            if (node == null || newNode == null )                                 //새 노드가 null일경우 또는 기존의 노드가 null일경우 에러반환
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)                                                //해당노드가 리스트에 들어가있지않을경우 에러발생
                throw new InvalidOperationException();

            newNode.next = node;                                                  //위치정보값 변경
            node.prev = newNode;
            newNode.prev = node.prev;

            if (node.prev == null)                                                //node가 헤드일경우 새로  head를 바꾸어주어야함
            {
                head = newNode;
            }
            else                                                                  //아닐경우 추가로 구현해주면됨
            {
                node.prev.next = newNode;
            }

            count++;                                                              //count 상승시켜주고 종료
        }

        public void AddAfter(LinkedListNode<T> node, T value)                     // AddBefore 과 유사하게 AddAfter 구현
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);       // 새노드 생성

            if (node == null || newNode == null)                                  // 예외처리구문 추가
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)
                throw new InvalidOperationException();

            newNode.next = node.next;                                             // 노드의 연결 바꿔주고
            newNode.prev = node;
            node.next = newNode;

            if (node == tail)                                                     // node가 tail일경우  newNode를 tail로바꿈
            {
                newNode = tail;
            }
            else
            {
                node.next.prev = newNode;
            }
            count++;                                                              // 숫자 1 올려줌
        }

        public LinkedListNode<T> Find(T value)                                    //Find 함수 만들어줌 비교해야할 value값을 매개변수로 받음.
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;           // 두값을 비교하기위한 비교클래스 인스턴스 생성.
            LinkedListNode<T> target = head;                                      // terget값을 list의 헤드로 지정
            while(target !=null)                                                  // target값이 null이아닐때까지 무한반복 -> list의 끝까지
            {
                if (comparer.Equals(value, target.Item) == true)                  // comparer내의 함수인equals를 사용하여 두 값이 동일할경우
                    return target;                                                // target을 반환하고 함수종료
                target = target.next;                                             // 아닐경우 target의 값을 다음 노드로바꿔줌
            }
            return null;                                                          // while문을 다돌았는데도 일치하는 값이 없으면 null반환
        }
        public void Remove(LinkedListNode<T> node)                                // Remove함수 구현 지워야할 노드값 받아옴
        {
            if(node == null)                                                      //노드가 null일때 예외발생
                throw new ArgumentNullException();
            if (node.list != this)                                                // 노드가 리스트내에 없을 때 예외발생
                throw new InvalidOperationException();

            if(node == tail)                                                      // 노드가 테일일경우 테일을 바꿔줌
                tail = node.prev;
            if (node.prev != null)                                                // 이전노드가 null이 아닐경우에 이전노드의next값을 null로 변경
                node.prev.next = null;

            if (node == head)                                                     // 노드가 헤드일경우 변경
                head = node.next;
            if (node.next !=null)                                                 // 이후 노드가 null이 아닐경우에 이후노드의prev값을 null로변경
                node.next.prev = null;
            count--;
        }

        public void Remove(T value)
        {

        }

    }

    public class LinkedListNode<T>
    {
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        public LinkedList<T> list;
        public T item;

        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public LinkedList<T> List { get { return list; } }
        public T Item { get { return item; } set { Item = item; } }

        public LinkedListNode(T value)
        {
            this.item = value;
            this.list = null;
            this.prev = null;
            this.next = null;
        }
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.item = value;
            this.prev = null;
            this.next = null;
        }

        public LinkedListNode(LinkedListNode<T> prev, LinkedListNode<T> next, LinkedList<T> list, T value)
        {
            this.prev = prev;
            this.next = next;
            this.list = list;
            this.item = value;
        }
    }

}
