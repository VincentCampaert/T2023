using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Domain.Model.Game
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
    }
}
