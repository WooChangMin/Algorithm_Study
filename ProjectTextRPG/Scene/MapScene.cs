using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTextRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            //TODO : 맵씬 표현 구현
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();                    // 버튼을 누를때 바로움직여야 하므로 리드라인보단 리드키가 좋아보임
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }

            // 플레이어 몬스터 접근
            Monster monster = Data.MonsterInPos(Data.player.pos);
            if(monster !=null)
            {
                // 전투 시작
                game.BattleStart(monster);
                return;
            }

            // 몬스터 이동
            foreach(Monster m in Data.monsters)
            {
                m.MoveAction();
                if (m.pos.x == Data.player.pos.x &&
                    m.pos.y == Data.player.pos.y)
                {
                    // 전투시작
                    game.BattleStart(m);
                    return;
                }
            }
        }

        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            StringBuilder sb = new StringBuilder();
            for(int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x =  0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.White;
            foreach(Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x*2, monster.pos.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x*2, Data.player.pos.y);
            Console.Write(Data.player.icon);
        }
    }
}
