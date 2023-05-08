using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM
{
    public abstract class Scene                                          // 상속해줄 부모 클래스 -> 추상화 이용
    {
        protected Game game;

        protected Scene(Game game)
        {
            this.game = game;
        }
        public abstract void Render();                               // 두개의 함수도 추상화로 선언

        public abstract void Update(); 
    }
}
