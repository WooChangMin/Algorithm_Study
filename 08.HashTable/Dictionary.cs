using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>               //키갑을 비교할수 는 있어야함.
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Delected}

            public State state;
            public int hashCode;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                //1. Key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                //2. key가 일치하는 데이터가 나올때 까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1 동일한 키값을 찾았을때 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                        
                    }
                    // 3-2 동일한 키값을 못찾고 비어있는 공간을 만났을때
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    // 3-3. 다음 index로 이동
                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                throw new InvalidOperationException();
            }

            set
            {  
                //1. Key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                //2. key가 일치하는 데이터가 나올때 까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;

                    }
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    index = index < table.Length - 1 ? index + 1 : 0;
                }
                throw new InvalidOperationException();

            }
        }
        public void Add(TKey key, TValue value)
        {
            /*
            대표적인 해싱함수 나눗셈법 -> 1119인경우 천의자리이상을 날리고 119에저장
            자릿수접기 1119인경우 한자리씩 접으면 1+1+1+9 두자릿수끼리 접으면 11+19
            string의 경우 각각 char하나하나를 유니코드의 정수로 변환후 자릿수접기.
            table 자체가 유한한 크기이므로 해싱과정에서 같은 인덱스를 가리키는 충돌문제가 생길수 있다.
            */

            // 1. 키값을 인덱스의 값으로 바꾸어주어야함 -> 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2.사용중이 아닌 index까지 다음으로 이동함.
            while (table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키값을 찾았을때 오류 (C# Dictionary 에서는 동일한 키값 허용 x)
                if (key.Equals(table[index].key))
                {
                    throw new ArgumentException();
                }

                // 3-2 다음 index로 이동
                index = index < table.Length-1 ? index + 1 : 0;
            }

            // 4. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        public bool Remove(TKey key)
        {
            // 1. 키값을 인덱스의 값으로 바꾸어주어야함 -> 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2.사용중이 아닌 index까지 다음으로 이동함.
            while (table[index].state == Entry.State.Using)
            {
                //3-1 동일한 키값을 찾았을때 지운 상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Delected;
                    return true;
                }
                // 3-2 동일한 키값을 못찾고 비어있는 공간을 만났을때
                else
                    break;


                index = ++index % table.Length;
            }

            return false;

        }
    }
}
