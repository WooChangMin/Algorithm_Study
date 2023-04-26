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
                return;
            }
            set
            {
                return;
            }
        }


        public void Add(TKey key, TValue value)                                                             // 값을 추가할때 -> key와 value 값을 입력받는다.
        {
            if (key == null)                                                                                // 들어온 key 값이 null일경우 예외상황 발생
                throw new ArgumentNullException();

            int index = Math.Abs(key.GetHashCode() % table.Length);                                         // 해싱함수는 C#에서 지원하는 GetHashCode함수를 사용하고 혹시나 해당 값이 table의 크기보다 클경우 테이블의 길이에 대한 나머지를
                                                                                                            // 계산해서 테이블 내의 인덱스에 매핑시킨다-> 해시코드가 음수일수도 있으므로 Math.Abs를 써서 절댓값으로 바꿔줌.
            while(table[index].state != Entry.State.None)                                                   // 테이블의 인덱스값의 상태가 None이 아닐경우 -> deleted 나 using일경우 아래로 내려가면서 찾아야함. 무한반복 
            {
                if (key.Equals(table[index].key))                                                           // 만약에 입력받은 키값과 현재의 index의 키값이 같은경우 ? 예외상황 발생 c# 에서는 중복 키값을 허용하지 않음.
                    throw new ArgumentException();
                index = ++index % table.Length;
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
                index = ++index% table.Length;                                                              // if문에 걸리지않았을경우 ? index값을 하나추가해주고 계속반복
            }
            return false;                                                                                   // while문을 다돌았는데도 return이 실행되지않을경우 해당 index내에 값이없다는 뜻이므로
        }                                                                                                   // return false 해주고 종료
    }
}
