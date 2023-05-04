using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectTextRPG
{
    

    public class Game                                              // 게임의 경우 '씬'이라는걸로 분할해서 구현을 하게됨 장면분할
    {
        private bool running = true;

        private Scene curScene;                                    // 현재 진행중인 씬에대한 정보
 
        private MainMenuScene mainMenuScene;
        private MapScene mapScene;
        private BattleScene battleScene;
        private InventoryScene inventoryScene;

        //private Dictionary<string, Scene> sceneDic;                // 씬이 많아질경우 Dictionary에 씬을 보관하는 방법도 가능

        public void Run()
        {
            // 초기화
            Init();

            //게임루프
            while (running)                                        //실시간 게임의 경우 입력 -> 랜더링 -> 갱신인경우가 많음 하지만 텍스트알피지는 실시간반영이아님.
            {
                // 랜더링
                Render();
                // 갱신
                Update();                                          // 텍스트 알피지의 경우 갱신에서 입력을 같이처리함 -> 되묻고 해당사항을 반영하는경우가 많음.
            }

            // 마무리 (게임 종료)
            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();
            mainMenuScene   = new MainMenuScene(this);
            mapScene        = new MapScene(this);
            battleScene     = new BattleScene(this);
            inventoryScene  = new InventoryScene(this);

            curScene        = mainMenuScene;
        }                             

        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene;
        }

        public void GameOver()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();

            Console.WriteLine(sb.ToString());

            running = false;
        }

        public void BattleStart(Monster monster)
        {
            curScene = battleScene;
        }

        private void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Release()
        {
            Data.Release();
        }


    }
}
