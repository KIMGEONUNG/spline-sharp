using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    /// <summary>
    /// Bezier curve implementation
    /// </summary>
    public class BezierSurface 
    {
        public BezierSurface(BezierCurve crv1, BezierCurve crv2)
        {
        }

        private Point3d GetTraject(Point3d[] pts, double t)
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

            return (1 - t) * GetTraject(prior, t) + t * GetTraject(post, t);
        }

        private Point3d BasicBezier(Point3d pt0, Point3d pt1, Point3d pt2, double t)
        {
            return (1 - t) * (1 - t) * pt0 + 2 * (1 - t) * t * pt1 + t * t * pt2;
        }

        private struct Point3d
        {
            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            public Point3d(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public Point3d(double[] xyz)
            {
                this.X = xyz[0];
                this.Y = xyz[1];
                this.Z = xyz[2];
            }

            public static Point3d operator *(Point3d pt, double val)
            {

                return new Point3d(pt.X * val, pt.Y * val, pt.Z * val);
            }

            public static Point3d operator *(double val, Point3d pt)
            {

                return new Point3d(pt.X * val, pt.Y * val, pt.Z * val);
            }

            public static Point3d operator +(Point3d pt1, Point3d pt2)
            {

                return new Point3d(pt1.X + pt2.X, pt1.Y + pt2.Y, pt1.Z + pt2.Z);
            }

            public override string ToString()
            {
                return $"X:{X}, Y:{Y}, Z:{Z}";
            }
        }
    }
}
