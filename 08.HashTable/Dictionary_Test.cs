using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
    internal class Dictionary_Test<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int initCapacity = 1024;

        private struct Entry
        {
            public enum State { None, Using, Deleted}

            internal State state;
            internal TKey key;
            internal TValue value;

        }

        private Entry[] table;
        
        public TValue this[TKey key]
        {
            get
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);                                     // 키를 해싱한후 값을 index에 저장해줌

                while (table[index].state != Entry.State.None)
                {
                    if (table[index].key.Equals(key))                                                       // 만약 인덱스의 키값이 넣어준 키값과 같을경우
                    {
                        return table[index].value;                                                          // 해당값을 반환해줌
                    }
                    index = ++index % table.Length;                                                         // 같은것을 찾지못할때마다 index에 값을 하나씩 추가해주어야함 혹시나 마지막 번호인경우 0으로 초기화
                }
                throw new InvalidDataException();                                                           // while문이 긑난경우 none에 도닫할때 까지 같은걸 찾지못했으므로 예외발생
            }
            set                                                                                             // key 따른 value로 새로 설정해줄떄
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);                                     //get과 비슷하게 따라가지만, 

                while (table[index].state != Entry.State.None)
                {
                    if (table[index].key.Equals(key))         
                    {
                        table[index].value = value;                                                         // 값만 변경을 해주면된다. return값이 없음
                    }
                    index = ++index % table.Length;           
                }
                throw new InvalidDataException();             
            }
        }


        public void Add(TKey key, TValue value)                                                             // 값을 추가할때 -> key와 value 값을 입력받는다.
        {
            if (key == null)                                                                                // 들어온 key 값이 null일경우 예외상황 발생
                throw new ArgumentNullException();

            int index = Math.Abs(key.GetHashCode() % table.Length);                                         // 해싱함수는 C#에서 지원하는 GetHashCode함수를 사용하고 혹시나 해당 값이 table의 크기보다 클경우 테이블의 길이에 대한 나머지를
                                                                                                            // 계산해서 테이블 내의 인덱스에 매핑시킨다-> 해시코드가 음수일수도 있으므로 Math.Abs를 써서 절댓값으로 바꿔줌.
            while(table[index].state != Entry.State.None)                                                   // 예외 처리구문! index 값을 1씩 더해가면서 None이나올때까지 확인하면서 반복 ! 해서 같은값이 있을경우 예외발생
            {
                if (key.Equals(table[index].key))                                                           // 만약에 입력받은 키값과 현재의 index의 키값이 같은경우 ? 예외상황 발생 c# 에서는 중복 키값을 허용하지 않음.
                    throw new ArgumentException();
                index = ++index % table.Length;
            }

            int index1 = Math.Abs(key.GetHashCode() % table.Length);                                        // 예외처리를 했으므로 해당 인덱스의 상태가 Deleted 나 None일 경우 값을 추가해줘야함. 
            while (true)                                                                                    // 무한반복
            {
                if (table[index1].state == Entry.State.Deleted || table[index1].state == Entry.State.None)  // 해당 조건부를 if로 걸어줌
                {
                    table[index1].key = key;                                                                // 값을 넣어주는 순서
                    table[index1].value = value;
                    table[index1].state = Entry.State.Using;
                    break;                                                                                  // break문으로 빠져나감
                }
                index1 = ++index1 % table.Length;                                                           // 인덱스의 값을 한개씩 더해가면서 while문 반복
            }

        }

        public bool Remove(TKey key)                                                                        // key가 들어왔을 때 제거하는 함수
        {
            if(key == null)                                                                                 // key가 null일 경우 예외처리 함수 
                throw new ArgumentNullException();

            int index = Math.Abs(key.GetHashCode() % table.Length);                                         // 키 값을 Add 와 동일하게 해싱해줌

            while (table[index].state != Entry.State.None)                                                  // table의 상태가 None이 아닐경우 -> using이거나 Deleted 면 게속 반복
            {
                if (key.Equals(table[index].key))                                                           // 만약 두개의 키값이 같은 경우면
                {
                    table[index].state = Entry.State.Deleted;                                               // 해당 state를 deleted로 바꿔주고
                    return true;                                                                            // 지우는데 성공했으므로 true 반환
                }
                index = ++index % table.Length;                                                              // if문에 걸리지않았을경우 ? index값을 하나추가해주고 계속반복
            }
            return false;                                                                                   // while문을 다돌았는데도 return이 실행되지않을경우 해당 index내에 값이없다는 뜻이므로
        }                                                                                                   // return false 해주고 종료
    }
}
