using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergerSebastien2.Models
{
    class Cercle : FormGeom
    {
        public override double calculateSurface()
        {
            double result = 0;

            result = Dim1 * 3.14;

            return result;
        }
    }
}
