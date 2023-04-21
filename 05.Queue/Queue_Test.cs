using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataStructure
{
    internal class Queue_Test<T>                                    // Queue 구현 해보기 순환구조로!
    {
        private const int DefaultCapacity = 4;                      // 기본 queue 배열을 위한 디폴트 값 설정.
        private T[] queue;                                          // T자료형의(일반화) 배열 생성. 이름은 queue
        private int head;                                           // head와 tail 두 index 지정.
        private int tail;

        public Queue_Test()                                         // 생성자 -> 디폴트값으로 T배열을 생성하고 head와 tail을 0으로 만들어줌 -> 큐가비었다.
        {
            queue = new T[DefaultCapacity];
            tail = 0;
            head = 0;
        }

        public T Dequeue()                                          // 큐에서 특정값을 빼는 함수, 반환값이 T
        {
            if (IsEmpty())                                          // queue가 비었을경우를 함수로 설정해서 bool값 반환으로 판별후에 true일경우 비었다는 말이므로 뺄수가 없으니 예외처리
                throw new InvalidOperationException();

            T item = queue[head];                                   // 반환받을 item을 queue[head]값에서 빼냄 큐의 경우 선입선출
            MoveNext(ref head);                                     // 해당 인덱스의 위치를 뒤로 이동시켜주는 함수를 생성 MoveNext로 ref 값을 받아서 실제값이 변경되도록 바꿈.
            return item;                                            //head값을 1만큼 뒤로이동시킨후 item을 반환시켜줌. 이전 head가 가리키는 값은 존재하지만 어차피위에 덮어쓰면 제거한것과 비슷한 효과
        }

        public void Enqueue(T item)                                 // 값을 넣어줄떄. 매개변수로 T를받음
        {
            if (IsFull())                                           // 큐가 꽉차면 넣어줄수가 없으므로 함수로 bool대수로 판별후 꽉찬경우에 Grow함수 실행
            {                                                       
                Grow();
            }
            queue[tail] = item;                                     // 넣어줄 값의 인덱스가 현제 tail이므로 item을 넣어줌
            MoveNext(ref tail);                                     // tail을 뒤로 한칸이동 이것도 레퍼런스 값 받음.
        }

        public T Peek()                                             // 맨윗단값을 빼오는방법
        {
            if (IsEmpty())                                          // 비었는지 확인후 true면 예외처리
                throw new InvalidOperationException();
            return queue[head];                                     // head값만 확인하면 됨.  array에는 변화x
        }

        public bool IsEmpty()                                       // 비었는 지판별하는 함수 head 가 tail일경우 비었음. 이경우가아니라면 두 값은 만나는 일이없음.
        {
            return head == tail;
        }

        public bool IsFull()                                        // 차있는지 확인하는 함수 순환 되었는지 아닌지 따로따로 판별이 필요함
        {
            if (head < tail)                                        // tail이 더클경우 순환이 안되었으므로 두 값을 뺀값이 길이와 같다면 꽉찬것
                return tail - head == queue.Length;
            else
                return head - tail == 1;                            // 반대의경우 head-tail 이 1이라면 꽉찬것
        }

        public void Grow()                                          // 꽉찼을때 큐의 크기를 확장시켜줄 필요성이 존재.
        {
            int newCapacity = queue.Length * 2;                     // 현재길이의 두배로 capacity 설정
            T[] newqueue = new T[newCapacity];                      // 새로운 길이의 newqueue생성
            if (tail > head)                                        // tail이 head 보다 큰경우 그대로 옮기면됨. Array.Coopy함수 사용
                Array.Copy(queue, 0, newqueue, 0, queue.Length );
            else
            {
                Array.Copy(queue, head, newqueue, 0, queue.Length - head);    //tail이 순환구조를 돌아서  head앞에있을경우 각각 따로 옮겨줘야함
                Array.Copy(queue, 0, newqueue, queue.Length - head, tail);    //head~ 배열의 끝까지를 새로운 함수의 처음부터 옮겨주고 그뒤에 이서 0~tail까지를 옮겨주면됨
            }
            head = 0;
            tail = queue.Length;
        }

        public void MoveNext(ref int index)                         // 뒤로한칸 이동시켜주는 함수
        {
            if (index == queue.Length - 1)                          // index가 길이 -1라면 인덱스를 0으로 초기화시켜줌 index는원래 총 개수의 -1임
            {
                index = 0;
            }
            index++;                                                // 아니라면 1만 추가해줌 
        }
    }
}
