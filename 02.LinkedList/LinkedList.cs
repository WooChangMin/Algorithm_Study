using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure1
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;
        
        public LinkedList<T> List { get { return list; } } 
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } set { item = value; } }

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
    }


    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }
        
        public LinkedListNode<T> AddFirst(T value)
        {
            // 1.새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            if (head != null)       // 2-1. Head 노드가 있었을 경우
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;     // 3. 새로운 노드를 head노드로 지정
            }
            else                    // 2-2. Head 노드가 없었을 때
            {
                head = newNode;
                tail = newNode;
            }

            count++;
            return newNode;
        }
        public LinkedListNode<T> AddLast(T value)          //동일한 방식으로 AddLast구현
        {
            // 새노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (tail != null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }

            count++;
            return newNode;
        }
    }
}
