using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure1
{
    internal class List<T>
    {

        
        public int size;
        private const int DefaultCount = 20;
        private T[] items;


        public int Capacity { get { return items.Length; } }          // Capacity의 경우 리스트의 크기를 바꾸지 않는 선에서 보유할수있는 최대량이므로 items.Length값을 넣어주는게맞고
        public int Count { get { return size; } }                     // Count의 경우 현재 들어가있는 요소의 개수이므로 size 가 적합하다.
        public List()
        {
            this.items = new T[DefaultCount];
            this.size = 0;
        }
        
        public T this[int index]                                      // indexer 구현 특정 index 값이 들어왔을경우 
        {
            get                                                       // index값이 들어왔을때 items[index] 값을 반환받을수 있고
            {                                                         
                if (index < 0 || index > size)                        // 예외처리구문
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set                                                       // 외부에서 해당 인덱스의 값을 변경해줄때도 예외처리구문과 함깨 값의 변경 -> return값은 존재x
            {
                if (index < 0 || index > size)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        public void Add(T item)                                       // Add() 구현 만들어진 리스트의 사이즈가 들어온 아이템의 개수보다 큰경우 바로대입하고 후위증감연산자를 사용해서 인덱스를 하나씩 늘려가면서 해당위치에 추가해줌
        {
            if (size > items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Expasion();
                items[size++] = item; 
            }   
        }

        public bool Remove(T item)                                    // index가 0보다 크거나같다 -> 배열내에 해당 요소가 있으므로 RemoveAt실행하고 지웠으므로 True값 반환 아닐경우 false 반환
        {
            int index = IndexOf(item);
            if (index >= 0 ) 
            {
                RemoveAt(Array.IndexOf(items, item));
                return true;
            }
            else
                return false;
        }

        public int IndexOf(T item)                                    //Array의 IndexOf함수를 사용하여 배열내에 요소가있을경우 해당 index반환 없을경우 -1 을반환.
        {
            return Array.IndexOf(items, item);
        }

        public void RemoveAt(int index)                               //RemvoeAt함수 -> index를 받아특정위치의 리스트내의 값을 삭제후 뒤쪽의 배열의값을 앞으로 당김. index가 사이즈보다크거나 0보다 작은경우 예외발생
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException(); 
            size--;                                                   // 총 크기도 줄어드므로 size   를 하나 줄여줘야함
            Array.Copy(items, index + 1, items, index, size - index); // items의 요소중에서 index+1의 값부터 size -index 개수만큼 items의 index값 부터 붙여서 복사하면된다.
           
        }

        public T? Find(Predicate<T> match)                            // Find함수 구현 특정 조건부에 맞는 경우가있는지 predicate대리자를 사용
        {
            if (match == null)                                        // match값이 null 일경우 예외 반환
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)                            // 그게 아닐경우 배열을 돌면서 해당 match의 값이 true인경우 item값을 리턴하고 종료
            {
                if (match(items[i]))
                {
                    return items[i];
                }
            }
            return default(T);
        }

        public int FindIndex(Predicate<T> match)                      // FindIndex의 경우 해당 인덱스를 찾을경우 가장 빠른 index반환하고 해당 함수가 없을경우 -1 반환
        {
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Expasion()                                        // Add() 함수구현을 위해 필요한 Expasion 함수 구현 혹시나 리스트의 사이즈를 넘어가는 자료형 데이터가 들어왔을때 해당 리스트의 크기를 두배로 키우는 작업을 수행 후 기존의 item위치를 newitem으로 대체
        {
            int newCapacity = items.Length * 2;
            T[] newitems = new T[newCapacity];
            Array.Copy(items, 0, newitems, 0, size);
            items = newitems;
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
        public bool Contains(T item)                                  // Contains함수 의경우 해당 배열안에 포함되어 있을경우 true 반환 없을경우 false 반환하는 함수이므로 IndexOf 함수를 사용해서 해당 반환값이 -1일경우 false 반환 아닐경우 true 반환.
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else return true;
        }
    }
}
