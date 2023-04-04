using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Web.Common.ViewModels
{
    public class PlayMoveViewModel
    {
        public int PlayerId { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int GameId { get; set; }
    }
}
