using Spline.BasisInfos;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Spline
{
    public abstract class BSpline : SplineBase
    {
        protected override Func<double, double> GetBasisFunction(BasisInfo _info)
        {
            BSplineBasisInfo info = (BSplineBasisInfo)_info; 

            int i = info.I;
            int j = info.J;
            KnotSet knots = info.Knots;

            Func<double, double> basis = GetBasis(i, j, knots);

            return basis;
        }

        /// <summary>
        /// Cox-de Boor recursion formula implementation. 
        /// </summary>
        protected Func<double,double> GetBasis(int i, int j, KnotSet knots)
        {
            Func<double, double> func = (t) =>
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

                 Func<double, double> firstTerm =  GetBasis(i, j - 1, knots);
                 Func<double, double> secondTerm = GetBasis(i + 1, j - 1, knots);

                 double first = firstTerm(t);
                 double second = secondTerm(t);

                 return coef1 * first + coef2 * second;
             };

           return func;
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
