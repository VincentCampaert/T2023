using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Domain.Model.Game
{
    public class HostGameModel
    {
        public string Name { get; set; }
        public int HostId { get; set; }
        public bool PrivateGame { get; set; }
        public int TurnLength { get; set; }
        public DateTime EndDate { get; set; }
    }
}
