using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    // C#의 경우 GC의 존재떄문에 LinkedList를 자제하는편이므로 queue를 그때그떄 구현하는편
    // C++의 경우 이와 다르게 Stack 과 Queue를 LinkedList로 Adapter로 구현해서 사용한다.
    // queue 도 배열기반으로 사용하기 위해서 환형구조로 만들어서 사용함
    // Enqueue와 Dequeue (삽입, 삭제)를 수행할때 각각 다른 선택기를 사용함 -> 선택기가 두개
    // 전단과 후단의 두선택기로 구현을 하고 두 선택기가 만났을경우 -> 스택이 꽉참or 비어있는것으로 인식
    // 그러므로 후단이 전단보다 한칸전에 있는경우 꽉차있는것으로 생각을함.

    internal class Queue<T>           
    {
        private const int DefaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;

        public int Count
        {
            get
            {
                if (head <= tail)
                    return tail - head;
                else
                    return tail - head + array.Length;
            }
        }
        
        public Queue()
        {
            if (IsFull())                                                 //추가하려는데 꽉차있을경우 크기를 키워주고늘려야함.
            {
                Grow();
            }
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();                  //비어있을경우 예외처리구문
            
            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();                   //비어있을경우 예외처리구문

            return array[head];
        }
        private void MoveNext(ref int index)                   //tail이 끝에있을경우 판별용 함수
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
        }            
        private bool IsEmpty()
        {
            return head == tail;
        }

        private bool IsFull()
        {
            if (head > tail)
                return head == tail + 1;
            else
                return head == 0 && tail == array.Length - 1;
        }

        public void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            if (head < tail)
            {
                Array.Copy(array, newArray, Count);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
                head = 0;
                tail = Count; 
            }
            
            array = newArray;
        }
    }                              
}                                            
                                             
                                             



