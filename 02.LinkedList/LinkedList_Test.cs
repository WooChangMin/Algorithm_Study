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
            LinkedListNode<T> newnode = new LinkedListNode<T>(this, value);       // 새노드를 만들어주고 이름 newnode

            if (node == null || newnode == null )                                 //새 노드가 null일경우 또는 기존의 노드가 null일경우 에러반환
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)                                                //해당노드가 리스트에 들어가있지않을경우 에러발생
                throw new InvalidOperationException();

            newnode.next = node;                                                  //위치정보값 변경
            node.prev = newnode;
            newnode.prev = node.prev;

            if (node.prev == null)                                                //node가 헤드일경우 새로  head를 바꾸어주어야함
            {
                head = newnode;
            }
            else                                                                  //아닐경우 추가로 구현해주면됨
            {
                node.prev.next = newnode;
            }

            count++;                                                              //count 상승시켜주고 종료
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
