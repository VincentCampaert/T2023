using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Data.EntityFramework
{
    public class DbInitializer
    {
        public static void Initialize(ReversiContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
