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


        public void Add(T item)                                    // Add() 구현 만들어진 리스트의 사이즈가 들어온 아이템의 개수보다 큰경우 바로대입하고 후위증감연산자를 사용해서 인덱스를 하나씩 늘려가면서 해당위치에 추가해줌
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

        public bool Remove(T item)
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

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
           
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
