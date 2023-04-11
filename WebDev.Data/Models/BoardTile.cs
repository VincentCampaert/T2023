using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Data.Models
{
    public class BoardTile : Entity
    {
        public int BoardId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int PlayerId { get; set; }
    }
}
