using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Data.Models
{
    public class Tile : Entity
    {
        public int? PlayerId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
