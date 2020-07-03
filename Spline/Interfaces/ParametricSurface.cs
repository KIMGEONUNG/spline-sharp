using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.Interfaces
{
    interface ParametricSurface
    {
        double[] ParameterAt(double u, double v);
    }
}
