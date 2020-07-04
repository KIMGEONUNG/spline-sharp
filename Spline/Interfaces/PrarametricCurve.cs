using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.Interfaces
{
    public interface ParametricCurve
    {
        double[] ParameterAt(double t);
    }
}
