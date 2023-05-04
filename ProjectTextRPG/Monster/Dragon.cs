using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectTextRPG.Astar;

namespace ProjectTextRPG
{
    public class Dragon : Monster
    {
        public override void MoveAction()
        {
            int MoveCount = 0;
            if (MoveCount++ % 2 != 0)
                return;
            List<Point> path;
            bool result = Astar.PathFinding(Data.map, new Astar.Point(pos.x, pos.y),
                new Point(Data.player.pos.x, Data.player.pos.y), out path);

            if (!result)
                return;

            if (path[1].y == pos.y - 1)
                Move(Direction.Up);
            else if (path[1].y == pos.y + 1)
                Move(Direction.Down);
            else if (path[1].y == pos.x - 1)
                Move(Direction.Left);
            else 
                Move(Direction.Right);
        }
    }
}
