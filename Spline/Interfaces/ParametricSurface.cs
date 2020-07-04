using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.Interfaces
{
    public interface ParametricSurface
    {
        double[] ParameterAt(double u, double v);
        int GetUCount();
        int GetVCount();
    }
}
