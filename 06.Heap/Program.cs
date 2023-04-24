namespace _06.Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/

        // 트리기반 노드
        // 1부모가 여러 자식을 가질수 있다. 2역순x -> 자식이 부모를 가져션 안된다(순환구조)
        // 순서가 일직선이아니므로 비선형 자료이다 (선형자료 -> 배열or리스트)

        static void PriorityQueue()                                 // 우선순위가 높은 순서대로 나옴.
        {
            PriorityQueue<string, int> acsendingPQ = new PriorityQueue<string, int>();

            acsendingPQ.Enqueue("감자", 5);                           //int = 우선순위 -> 꼭 정수형 자료형이 아니더라도 비교할수있는 자료형이면 됨.
            acsendingPQ.Enqueue("양퍄", 1);
            acsendingPQ.Enqueue("마늘", 2);
            acsendingPQ.Enqueue("고구마", 3);
            acsendingPQ.Enqueue("가지", 4);

            while(acsendingPQ.Count > 0)
            {
                Console.WriteLine(acsendingPQ.Dequeue());               // queue 와 달리 우선순위가 높은 순서대로 나옴.
            }

            PriorityQueue<string, int> desendingPQ                      // 점수가 높은것부터 뽑는방법..
                = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            desendingPQ.Enqueue("감자", 5);                           
            desendingPQ.Enqueue("양퍄", 1);
            desendingPQ.Enqueue("마늘", 2);
            desendingPQ.Enqueue("고구마", 3);
            desendingPQ.Enqueue("가지", 4);

            while (desendingPQ.Count > 0)
            {
                Console.WriteLine(desendingPQ.Dequeue());               
            }
        }

        // 시간복잡도
        // 탐색(가장우선수위)   추가       제거
        // O(1)               O(logN)   O(logN)
        static void Main(string[] args)
        {
            PriorityQueue();

        }
    }
}