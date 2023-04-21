using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
     // Adapter 에서는 일련의 과정이 필요가없음 -> 이미 List에 구현이되어있음.
     /* private List<T> list;
        private int count;
        private const int DefaultCapacity = 10;

        public Stack_Test()
        {
            this.list = list;
            count = 0;
        }

        public void Push(T item)
        {
            if(count == list.Count)
            {
                Grow();
            }
            list.Add(item);
        }

        public void Grow(List<T> list)
        {
            int newCapacity = list.Count * 2;
            T[] newlist = new T[newCapacity];
            Array.Copy(list, newlist, list.Count);
            list = newlist;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    internal class Stack_Test<T>                                // 어댑터패턴 방식으로 Stack을 List 클래스를 사용하여 구현하기 generic사용 <T> 다양한데이터타입을 받기위해
    {
        public List<T> list;                                    // 해당 리스트가 어떤리스트를 가리키는지 가지고있어야한다. 

        public Stack_Test()                                     // 생성자 만들어줌 
        {
            list = new List<T>();                               // 새로운 리스트배열을 하나 만듬.
        }

        public void Push(T item)                                // Stack에값을 넣어줄경우 Push함수로 사용
        {
            list.Add(item);                                     // List에 있는 Add함수를 사용할경우 배열의 뒤쪽부터 데이터값이 들어가게됨.
        }

        public T Pop()                                          // Stack의 Pop함수 Stakc에서 맨마지막값 가장윗값을 빼는법.
        {
            if(list.Count == 0)                                 // list의 개수가 0 일경우 뺄 객체가 없으니까 예외처리 구문발생.
                throw new InvalidOperationException();
            T item = list.Last();                               // Pop의 경우 마지막 값을 반환해야하므로 반환을 위한 List의 Last()함수를 사용하여서 마지막 값을 자료형T 의 Item에 넣어줌
            list.RemoveAt(list.Count-1);                        // List의 RemoveAt함수를 사용하여  Count -1 값을 넣어서 맨마지막 인덱스를 넣어줌 -> 삭제됨 count--; 까지 list의 함수내에서 실행
            return item;                                        // item갑을 반환해줌
        }

        public T Peek()                                         // Peek함수의 경우 맨 윗단값을 확인하고 싶을때 사용함 -> Stack구조에는 영향x
        {
            if (list.Count == 0)                                // 똑같이 예외처리구문 Stack내의 값이없으면 뺄 값이 없음.
                throw new InvalidOperationException();
            return list.Last();                                 // Last() 함수사용 마지막 값을 반환받음
        }
    }
    
}
