using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BergerSebastien2.Controller;

namespace BergerSebastien2
{
    class Program
    {
        static void Main(string[] args)
        {
            FormGeomController controller = new FormGeomController();
            controller.displayList();
        }
    }
}
