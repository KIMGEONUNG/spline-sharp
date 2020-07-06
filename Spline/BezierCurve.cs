using Spline.BasisInfos;
using Spline.Enums;
using Spline.Interfaces;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;

namespace Spline
{
    /// <summary>
    /// Bezier curve implementation
    /// </summary>
    public class BezierCurve : BezierSpline, ParametricCurve
    {
        private Point3d[] points;

        public BezierCurve(IEnumerable<IEnumerable<double>> pts)
        {
            var pointList = new List<Point3d>();

            foreach (var pt in pts)
            {
                Point3d pt3d = new Point3d(pt.ToArray());
                pointList.Add(pt3d);
            }

            this.points = pointList.ToArray();
        }

        public int GetDegree()
        {
            return points.Length - 1;
        }

        public int GetOrder()
        {
            return GetDegree() + 1;
        }

        protected override Func<double, double> GetBasisFunction(BasisInfo _info)
        {
            BezierBasisInfo info = (BezierBasisInfo)_info;

            int n = info.N;
            int i = info.I;

            Func<double, double> func = (t) => MathTool.GetBinomialCoefficient(n, i) * Math.Pow(t, i) * Math.Pow(1 - t, n - i);

            return func;
        }

        public double[] ParameterAt(double t)
        {
            int n = points.Length - 1;
            Point3d result = new Point3d(0, 0, 0);

            for (int i = 0; i <= n; i++)
            {
                Point3d pt = points[i];
                BasisInfo info = new BezierBasisInfo(n, i);
                Func<double, double> basis = this.GetBasisFunction(info);
                double val = basis(t); 

                result += val * pt;
            }

            return new double[] { result.X, result.Y, result.Z };
        }

        public double[] GetPointWithRecursive(double t)
        {
            Point3d target = GetPointWithRecursion(t);

            return new double[] { target.X, target.Y, target.Z };
        }

        private Point3d GetPointWithRecursion(double t)
        {
            int len = points.Length;
            if (len < 3)
            {
                throw new Exception();
            }
            if (len == 3)
            {
                return BasicBezier(points[0], points[1], points[2], t);
            }

            var prior = points.ToList().GetRange(0, len - 1).ToArray();
            var post = points.ToList().GetRange(1, len - 1).ToArray();

            return (1 - t) * GetPointWithRecursion(t) + t * GetPointWithRecursion(t);
        }

        private Point3d BasicBezier(Point3d pt0, Point3d pt1, Point3d pt2, double t)
        {
            return (1 - t) * (1 - t) * pt0 + 2 * (1 - t) * t * pt1 + t * t * pt2;
        }
    }
}
