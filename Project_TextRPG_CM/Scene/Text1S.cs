using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM
{
    internal class Text1S : Scene
    {
        public Text1S(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("옛날옛날 먼 옛날 창조주께서 하나의 차원과 천사와 인간 그리고 마족을 만드셨습니다.");
            Thread.Sleep(2000);
            Console.WriteLine( );
            Console.WriteLine("천사는 천계에서 인간은 지계에서 마족은 마계에서 각자의 삶을 영위하며 살아갔습니다.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("어느날 천계의 대천사인 루시퍼가 반란을 계획하다 실패하여 마계로 추방당했습니다.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("루시퍼는 복수를 다짐하며 힘을키워 마계의 왕이 되었고, 마족들을 통솔하여 천계를 공격하기에 이릅니다.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("이는 신마대전으로 불리며, 수많은 사상자와 차원이 멸망직전까지 가게되고 실망한 창조주는 차원을 외면해버립니다.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("창조주를 잃어버린 차원과 피조물들은 쇠락의 길을 걷게됩니다....만");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("제2 군단장이었던 당신은 격투에 재능이 있었으나 선천적으로 싸움을 좋아하지 않았고");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("창조주는 당신에게 하나의 가능성을 발견하여 다시 기회를 주려합니다...");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("창조주의 전능한 권능으로 100년전으로 회귀한 당신! 루시퍼를 저지하고 차원의 멸망을 막아주세요.");
            Thread.Sleep(2000);
            Console.WriteLine();    
        }

        public override void Update()
        {
            Console.Write("스페이스바를 누르시면 마을로 출발합니다. :  ");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Spacebar:
                    game.Map();
                    break;
                default:
                    Console.WriteLine("Y또는 N값을 눌러주세요!");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}
