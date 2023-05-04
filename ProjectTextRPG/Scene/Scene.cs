using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTextRPG
{
    public abstract class Scene                                 // "씬" 이라고하는 씬은 없으므로 추상 클래스로 구현 -> 배틀씬 보스씬 메인씬 등등 특정조건별로 씬이 존재함
    {

        protected Game game;                                    // "씬" 도 어떤게임내에 있는지 가지고있을 필요가있음. 소속에대한 정보.

        public Scene(Game game)                                 // 초기화
        {
            this.game = game;
        }

        public abstract void Render();

        public abstract void Update();

    }
}
