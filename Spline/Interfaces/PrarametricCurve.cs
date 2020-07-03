using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.Interfaces
{
    interface ParametricCurve
    {
        double[] ParameterAt(double t);
    }
}
