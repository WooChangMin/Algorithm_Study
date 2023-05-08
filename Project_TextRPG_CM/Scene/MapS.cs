using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM
{
    internal class MapS : Scene
    {
        public MapS(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
            PrintMenu();

        }

        public override void Update()
        {
            var input = Console.ReadKey();
        }

        public void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.White;
            for(int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x= 0; x< Data.map.GetLength(1); x++)
                {
                    switch (Data.map[y, x])
                    {
                        case 0:
                            Console.Write("　");
                            break;
                        case 1:
                            Console.Write("■");
                            break;
                        case 2:
                            Console.Write("◇");
                            break;
                        case 3:
                            Console.Write("☞");
                            break;
                        case 4:
                            Console.Write("★");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(Data.map.GetLength(1) + 3, 1);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data.map.GetLength(1) + 5, 1);
            Console.Write("인벤토리 : I");
        }
    }
}
