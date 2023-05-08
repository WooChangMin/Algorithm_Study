using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG_CM
{
    public class Demon
    {
        public Position pos;

        public 
        enum Rank {slave, knight, Viscount, Duke, King, Emperor, NPC}
        
        
        public int hp;
        public int mp;
        public int gold;
        public int AttackPoint;
        
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
            if (Data.map[pos.y, pos.x] == 1)
            {
                pos = prevPos;
            }

        }
    }
}
