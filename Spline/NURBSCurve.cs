using Spline.BasisInfos;
using Spline.Interfaces;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Spline
{
    public class NURBSCurve : BSpline, ParametricCurve
    {
        protected Point3d[] points;
        private double[] weights;
        protected KnotSet knotVector;
        protected int degree;

        public NURBSCurve(IEnumerable<IEnumerable<double>> pts, KnotSet knotset, IEnumerable<double> weights, int degree)
        {
            var pointList = new List<Point3d>();

            foreach (var pt in pts)
            {
                Point3d pt3d = new Point3d(pt.ToArray());
                pointList.Add(pt3d);
            }

            this.points = pointList.ToArray();
            this.knotVector = (KnotSet)knotset.Clone();
            this.degree = degree;
            this.weights = weights.ToArray();
        }

        public double[] ParameterAt(double t)
        {
            int n = points.Length - 1;
            Point3d result = new Point3d(0, 0, 0);

            if (t == this.knotVector.GetMaxKnot())
            {
                result = points.Last();
            }
            else
            {
                for (int i = 0; i <= n; i++)
                {
                    Point3d pt = points[i];
                    double weight = this.weights[i];

                    BasisInfo info = new BSplineBasisInfo(i, degree, knotVector);
                    var basis = GetBasisFunction(info);
                    double val = basis(t);

                    result += val * pt * weight;
                }
                double denominator = GetRationalBasisDenominator(t);

                if (denominator == 0)
                {
                    throw new DivideByZeroException();
                }

                result /= denominator;
            }

            return new double[] { result.X, result.Y, result.Z };
        }

        private double GetRationalBasisDenominator(double t)
        {
            int n = weights.Length - 1;

            double denominator = 0;
            for (int i = 0; i <= n; i++)
            {
                BasisInfo info = new BSplineBasisInfo(i, degree, knotVector);

                Func<double, double> basis = GetBasisFunction(info);
                double weight = this.weights[i];

                denominator += basis(t) * weight;
            }

            return denominator;
        }
    }
}
