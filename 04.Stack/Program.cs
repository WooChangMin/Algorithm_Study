using _DataStructure;

namespace _04.Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        /*
        static void Test()
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 10; i++) stack.Push(i);      //0 1 2 3 4 5 6 7 8 9

            Console.WriteLine(stack.Peek());

            while (stack.Count > 0)                          //최상단 : 9
            {
                Console.WriteLine( stack.Pop() );            // 9 8 7 6 5 4 3 2 1 0
            }
        }*/

        static void Test()                                                         //Stack을 실험하기위한 Test 함수
        {
            Stack_Test<int> stack = new Stack_Test<int>();
            for (int i = 0; i < 5; i++) stack.Push(i);
            Console.WriteLine(stack.Peek());
            for (int i = 0; i < 5; i++) Console.WriteLine(stack.Pop()); 
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}