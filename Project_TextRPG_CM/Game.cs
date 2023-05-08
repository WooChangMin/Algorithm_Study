using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project_TextRPG_CM
{
    public class Game
    {
        private bool running = true;                                        // running변수
        
        private Scene curScene;

        private MainMenuS main;
        private BattleS battle;
        private InvetoryS inven;
        private ShoppingS shop;
        private Text1S text1;
        private MapS map;

        public void Run()
        {
            GameInit();
            
            while (running)
            {
                GameRender();
                GameUpdate();
            }

            GameRelease();
        }


        /*
        private Dictionary<string, Scene> SceneDic = new Dictionary<string, Scene>()               // 포기
        {
            {"main"  , new MainMenuS(this) },
            {"inven" , new InvetoryS() },
            {"battle", new BattleS() },
            {"shop"  , new ShoppingS() },
            {"text1" , Text1S },
            {"text2" , Text1S },
            {"text3" , Text1S },

        };
        */

        public void GameRender()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();

        }

        public void GameInput()
        {

        }

        public void GameUpdate()
        {
            curScene.Update();

        }

        public void GameRelease()
        {

        }
        public void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            sb.AppendLine("************Game Over***********");
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
            running = false;
        }

        public void GameStart()
        {
            curScene = text1;
        }
        public void GameClear()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GameClear");
            Console.WriteLine(sb.ToString());
            Thread.Sleep(3000);
            running = false;
        }

        public void GameInit()
        {
            Console.Clear();
            Console.CursorVisible = false;

            main = new MainMenuS(this);
            shop = new ShoppingS(this);
            battle = new BattleS(this);
            inven = new InvetoryS(this);
            text1 = new Text1S(this);
            map = new MapS(this);

            curScene = map;
        }

        public void Inven()
        {
            curScene = inven;
        }

        public void Battle()
        {
            curScene = battle;
        }

        public void Shop()
        {
            curScene = shop;
        }

        public void Map()
        {
            curScene = map;
            map.GenerateMap();
        }
    }
}
