using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Domain.Model.Game
{
    public class Player
    {
        public int UserId { get; set; }
        public Person Person { get; set; }
    }
}
