using Spline.BasisInfos;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Transactions;

namespace Spline
{
    public class NURBS : BSpline
    {
        /// <summary>
        /// Rational basis 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        protected override Func<double, double> GetBasisFunction(BasisInfo _info)
        {
            NURBSBasisInfo info = (NURBSBasisInfo)_info;

            int i = info.I;
            int j = info.J;
            KnotSet knots = info.Knots;
            double[] weights = info.Weights;

            Func<double, double> basis = GetRationalBasis(i, j, knots, weights);

            return basis;
        }
        private Func<double, double> GetRationalBasis(int i, int j, KnotSet knots, double[] weights)
        {
            // the number of control points
            int n = weights.Length - 1;
            double w = weights[i];

            Func<double, double> func = (t) =>
             {
                 double denominator = 0;
                 for (int k = 0; k <= n; k++)
                 {
                     double val = GetBasis(k, j, knots)(t) * weights[k];
                     denominator += val;
                 }

                 double result = (GetBasis(i, j, knots)(t) * w) / denominator;

                 return result;
             };

            return func;
        }
    }
}
