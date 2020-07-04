using Spline.Interfaces;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    /// <summary>
    /// Implementation for B-spline
    /// </summary>
    public class BSplineCurve : BSpline, ParametricCurve
    {
        protected Point3d[] points;
        protected KnotSet knotVector;
        protected int degree;

        public BSplineCurve(IEnumerable<IEnumerable<double>> pts, KnotSet knots, int degree)
        {
            var pointList = new List<Point3d>();

            foreach (var pt in pts)
            {
                Point3d pt3d = new Point3d(pt.ToArray());
                pointList.Add(pt3d);
            }

            this.points = pointList.ToArray();
            this.knotVector = (KnotSet)knots.Clone();
            this.degree = degree;
        }

        public virtual double[] ParameterAt(double t)
        {
            Point3d result = new Point3d(0, 0, 0);

            int n = points.Length - 1;

            for (int i = 0; i <= n; i++)
            {
                Point3d pt = points[i];
                double val = GetBasis(i, degree, this.knotVector, t);

                result = result + val * pt;
            }
            return new double[] { result.X, result.Y, result.Z };
        }

    }
}
