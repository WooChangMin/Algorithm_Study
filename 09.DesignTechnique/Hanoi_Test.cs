namespace Hanoi_Test
{
    internal class HanoiTest
    {
        public static void Move(int count , int start, int end)
        {
            if (count == 1)
            {
                int value = stick[start].Pop();
                stick[end].Push(value);
                Console.WriteLine($"{start+1} {end+1}");
                return;
            }
            Move(count -1 , start, 3-start-end);
            Move(1, start, end);
            Move(count - 1, 3 - start - end, end);
        }

        public static Stack<int>[] stick;

        public void Test()
        {

            
            int count = int.Parse(Console.ReadLine());
            stick = new Stack<int>[3];
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>();
            }

            for (int i = count; i>0; i--)
            {
                stick[0].Push(i);
            }
            Console.WriteLine(Math.Pow(2,count)-1);
            if (count <= 20)
            {
                Move(count, 0, 2);
            }
        }
    }
}