using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Domain.Model.Game
{
    public class PlayMoveModel
    {
        public int PlayerId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int GameId { get; set; }
    }
}
