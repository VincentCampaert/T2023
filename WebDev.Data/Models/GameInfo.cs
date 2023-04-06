using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Data.Models
{
    public class GameInfo : Entity
    {
        public bool Started { get; set; }
        public int CurrentTurn { get; set; }
        public int CurrentSide { get; set; }
        public IEnumerable<Tile> ClaimedTiles { get; set; }

        // Foreign
        public int GameId { get; set; }
    }
}
