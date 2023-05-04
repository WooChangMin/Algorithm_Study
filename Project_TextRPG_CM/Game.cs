using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM
{
    public class Game
    {

        private string name;
        private bool running = true;

        public void GameRender()
        {

        }

        public void GameInput()
        {

        }

        public void GameUpdate()
        {


        }
        public void GameOver()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GameOver");
            Thread.Sleep(2000);
            running = false;
        }

        public void GameClear()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GameClear");
            Thread.Sleep(2000);
            running = false;
        }
    }
}
