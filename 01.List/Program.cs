using System.Collections.Generic;
namespace _01.List
{
    internal class Program
    {
        /******************************************************
		 * 배열 (Array)
		 * 
		 * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨 -> 배열의경우 추가와 삭제의 데이터에 사용이 부적합하다.
		 * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
		 ******************************************************/

        //배열의 사용
        void Array()
        {
            int[] intArray = new int[100];

            //인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];
        }
        // <배열의 시간복잡도>
        // 접근         탐색
        // O(1)        O(N)

        /******************************************************
		 * 동적배열 (Dynamic Array)
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 * 배열요소의 갯수를 특정할 수 없는 경우 사용
		 ******************************************************/

        // <List의 사용> List<자료형> List이름 = new List<자료형>();
        void List()
        {
            List<string> list = new List<string>();

            // 배열 요소 삽입
            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");

            // 배열 요소 삭제
            list.Remove("1번 데이터");

            // 배열 요소 접근
            list[0] = "데이터0";
            string value = list[0];

            // 배열 요소 탐색
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }
        // <List의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(1)		O(n)	O(n)	O(n)

        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            //list.Count
            //list.Capacity

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));

        }
        // Array, ArrayList, List 차이?
        /* 셋다 자료형을 담아놓을수 있는 Collection의 역할을 하지만 
         * Array의 경우 생성 초기에 크기가 지정해서 생성되기에 새로운 요소의 추가와 삭제가 어렵다. 다차원 배열의 입력이 가능하다.
         * List의 경우 다르게는(Dynamic Array)라고도 불리며, 생성초기에 크기가 지정되는게 아니라 동적으로 크기를 할당하기에 새로운 자료의 추가와 삭제가 자유롭다. (보이기만 그렇고 실제로는 큰 영역의 값을 미리 할당해놓는 방식)
         * ArrayLIst의 경우 List와 대부분 동일하지만 여러가지 자료형을 동시에 가지고 있을수 있다. 하지만 그만큼 처리속도가 저하되기에 특정 상황 말고는 잘 사용되지 않는다.
         */
    }
}