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


        public List()
        {
            this.items = new T[DefaultCount];
            this.size = 0;
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

        public void Expasion()                                     // Add() 함수구현을 위해 필요한 Expasion 함수 구현 혹시나 리스트의 사이즈를 넘어가는 자료형 데이터가 들어왔을때 해당 리스트의 크기를 두배로 키우는 작업을 수행 후 기존의 item위치를 newitem으로 대체
        {
            int newCapacity = items.Length * 2;
            T[] newitems = new T[newCapacity];
            Array.Copy(items, 0, newitems, 0, size);
            items = newitems;
        }
    }
}
