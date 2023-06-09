﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Iterator
{
    internal class List<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }
        public T this[int index]                           // 인덱서를 활용해서 리스트의 특정 인덱스에 접근가능.
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)                            // 특정 리스트에 item을 추가하는 방법 -> 배열보다 큰경우 예외 추가필요
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


        public bool Remove(T item)                         // RemoveAt함수를 사용한 Remove 함수 구현
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

        public void RemoveAt(int index)                    // Array.Copy를 사용하여 특정 인덱스의 값을 지우고 그 인덱스뒤의 인덱스들의 값을 한칸씩 땡김.
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public int IndexOf(T item)                          //특정 인덱스의 값을 찾는 방법 int값으로 반환되며 +1 일경우 있음, -1 경우 없음을 나타냄
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return i;
            }

            return -1;
        }
        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newitems = new T[newCapacity];
            Array.Copy(items, 0, newitems, 0, size);
            items = newitems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private int index;
            private T current;

            public T Current { get { return list[index]; } }

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.index = -1;
                this.current = default(T);
            }
            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (index < list.Count - 1)
                {
                    current = list[++index];
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }
}
