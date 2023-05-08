using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM 
{
    internal class MainMenuS : Scene
    {
        public MainMenuS(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***************************************");
            sb.AppendLine("************  마족 키우기  ************");
            sb.AppendLine("************  마족 키우기  ************");
            sb.AppendLine("************  마족 키우기  ************");
            sb.AppendLine("************  마족 키우기  ************");
            sb.AppendLine("************  마족 키우기  ************");
            sb.AppendLine("***************************************");

            sb.AppendLine();
            sb.AppendLine("        게임을 시작하시겠습니까?   Y     ");
            sb.AppendLine("        게임을 종료하시겠습니까?   N     ");
            sb.Append("              입력해주세요 :   ");
            Console.Write( sb.ToString());
        }

        public override void Update()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("잠시후 게임이 시작됩니다!");
                    Thread.Sleep(1500);
                    game.GameStart();
                    break;
                case ConsoleKey.N:
                    Thread.Sleep(1000);
                    game.GameOver();
                    break;
                default:
                    Console.WriteLine("Y또는 N값을 눌러주세요!");
                    Thread.Sleep(1500);
                    break;

            }
        }
    }
}
