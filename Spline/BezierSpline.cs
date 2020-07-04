using Spline.BasisInfos;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spline
{
    public abstract class BezierSpline : SplineBase
    {
        protected override Func<double, double> GetBasisFunction(BasisInfo _info)
        {
            BezierBasisInfo info = (BezierBasisInfo)_info;

            int n = info.N;
            int i = info.I;

            Func<double, double> func = (t) => MathTool.GetBinomialCoefficient(n, i) * Math.Pow(t, i) * Math.Pow(1 - t, n - i);

            return func;
        }
    }
}
