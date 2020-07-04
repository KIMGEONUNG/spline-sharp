using Spline.BasisInfos;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spline
{
    public abstract class BSpline : SplineBase
    {
        protected override Func<double, double> GetBasisFunction(BasisInfo _info)
        {
            BSplineBasisInfo info = (BSplineBasisInfo)_info; 

            int n = info.N;
            int i = info.I;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Cox-de Boor recursion formula implementation. 
        /// </summary>
        protected double GetBasis(int i, int j, KnotSet knots, double t)
        {
            double t_i = knots.GetIndexOf(i);
            double t_iplus1 = knots.GetIndexOf(i + 1);

            if (j == 0)
            {
                if (t_i <= t && t < t_iplus1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            double coef1 = GetCoef(i, j, t, knots);
            double coef2 = 1 - GetCoef(i + 1, j, t, knots);

            double firstTerm = coef1 * GetBasis(i, j - 1, knots, t);
            double secondTerm = coef2 * GetBasis(i + 1, j - 1, knots, t);

            return firstTerm + secondTerm;
        }

        /// <summary>
        /// Cox-de Boor recursion formula implementation. 
        /// </summary>
        protected  double GetCoef(int i, int j, double t, KnotSet knots)
        {
            if (knots.GetIndexOf(i + j) == knots.GetIndexOf(i))
            {
                return 0;
            }

            return (double)(t - knots.GetIndexOf(i)) / (double)(knots.GetIndexOf(i + j) - knots.GetIndexOf(i));
        }
    }
}
