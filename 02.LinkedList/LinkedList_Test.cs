using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Datastructure
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int count;


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
