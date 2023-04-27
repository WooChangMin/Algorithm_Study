namespace _09.DesignTechnique
{
    internal class Program
    {
        /******************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
		 * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
		 ******************************************************/

        public enum Place { Left, Middle, Right }

        public void Hanoi()
        {
            Move(6, 0,2);

        }

        public static void Move(int count, int start, int end)
        {
            if(count == 1)
            {
                //그냥 이동
                int node = stick[start].Pop();
                stick[end].Push(node);
                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {node} 이동"); 
                return;
            }

            int other = 3 - start - end;
            Move(count - 1, start, other);                // n-1개 움직이고
            Move(1, start, end);                          // n번째 움직이고
            Move(count - 1, other, end);                  // n-1개움직이기

        }

        public static Stack<int>[] stick;


        /*public static int CountTime(params int[] task)
        {
            Array.Sort(task);

            int result = 0;

        }
        */

        

        static void Main(string[] args)
        {
            int[,] result;

            /*int nodeCount = 7;
            
            stick = new Stack<int>[3];
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>();
            }
            for(int i = nodeCount; i>0; i--)
            {
                stick[0].Push(i);
            }

            Move(nodeCount, 0, 2);
            */
        }
    }
}