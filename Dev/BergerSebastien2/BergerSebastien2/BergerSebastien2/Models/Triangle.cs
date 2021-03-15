using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergerSebastien2.Models
{
    class Triangle : FormGeom
    {
        public override double calculateSurface()
        {
            double result = 0;

            if (Dim2 is double)
            {
                result = (Dim1 * (double)Dim2) / 2;
            }

            return result;
        }
    }
}
