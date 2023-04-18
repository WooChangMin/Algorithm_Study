using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class List<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int size;
        
        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public void Add(T item)
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;

            }
        }


        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                //TODO : 지우기작업
                RemoveAt(index);
                return true;
            }
            else
            {
                // 못찾은 경우
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }
        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newitems = new T[newCapacity];
            Array.Copy(items, 0, newitems, 0, size);
            items = newitems; 
        }
    }
}
