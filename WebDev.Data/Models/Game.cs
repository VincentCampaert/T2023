using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Data.Models
{
    public class Game : Entity
    {
        public int Player1Id { get; set; } // Host
        public int Player2Id { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public int TurnLength { get; set; }
        public DateTime EndDate { get; set; }
    }
}
