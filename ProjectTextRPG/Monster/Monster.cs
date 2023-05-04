using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTextRPG
{
    public abstract class Monster                                 // 몬스터또한 추상클래스 사용
    {
        public char icon = 'ⓜ';
        public Position pos;

        public abstract void MoveAction();

        public void Move(Direction dir)
        {
            Position prevPos = pos;
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }
            // 이동한 자리가 벽일 경우
            if (!Data.map[pos.y, pos.x])
            {
                // 원위치 시키기
                pos = prevPos;
            }
        }
    }

}
