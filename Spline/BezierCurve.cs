using Microsoft.VisualBasic.CompilerServices;
using Spline.Enums;
using Spline.Interfaces;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    /// <summary>
    /// Bezier curve implementation
    /// </summary>
    public class BezierCurve : SplineBase, ParametricCurve
    {
        private BezierAlgorithms algorithm;
        private Point3d[] points;

        public BezierCurve(IEnumerable<IEnumerable<double>> pts, BezierAlgorithms _algorithm = BezierAlgorithms.BerteinPolynomial)
        {
            var pointList = new List<Point3d>();

            foreach (var pt in pts)
            {
                Point3d pt3d = new Point3d(pt.ToArray());
                pointList.Add(pt3d);
            }

            this.points = pointList.ToArray();
            this.algorithm = _algorithm;
        }

        public int GetDegree()
        {
            return points.Length - 1;
        }

        public int GetOrder()
        {
            return GetDegree() + 1;
        }

        public double[] ParameterAt(double t)
        {
            Point3d pt = new Point3d();

            switch (this.algorithm)
            {
                case BezierAlgorithms.BerteinPolynomial:
                    pt = GetPointWithBernstein(this.points, t);
                    break;
                case BezierAlgorithms.Recursion:
                    pt = GetPointWithRecursion(this.points, t);
                    break;
                default:
                    throw new InvalidOperationException("Invalid algorithm type for Bezier");
            }

            return new double[] { pt.X, pt.Y, pt.Z };
        }

        private Point3d GetPointWithBernstein(Point3d[] pts, double t)
        {
            int len = pts.Length;
            if (len < 3)
            {
                throw new Exception();
            }
            int n = len - 1;
            Point3d target = new Point3d(0, 0, 0);
            for (int i = 0; i <= n; i++)
            {
                Point3d pt = pts[i];
                Func<double, double> basis = MathTool.GetBernsteinPolynomialBasis(n, i);

                target += basis(t) * pt;
            }

            return target;
        }

        private Point3d GetPointWithRecursion(Point3d[] pts, double t)
        {
            int len = pts.Length;
            if (len < 3)
            {
                throw new Exception();
            }
            if (len == 3)
            {
                return BasicBezier(pts[0], pts[1], pts[2], t);
            }

            var prior = pts.ToList().GetRange(0, len - 1).ToArray();
            var post = pts.ToList().GetRange(1, len - 1).ToArray();

            return (1 - t) * GetPointWithRecursion(prior, t) + t * GetPointWithRecursion(post, t);
        }

        private Point3d BasicBezier(Point3d pt0, Point3d pt1, Point3d pt2, double t)
        {
            return (1 - t) * (1 - t) * pt0 + 2 * (1 - t) * t * pt1 + t * t * pt2;
        }
    }
}
