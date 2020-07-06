using Spline.BasisInfos;
using Spline.Interfaces;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Spline
{
    /// <summary>
    /// Bezier curve implementation
    /// </summary>
    public class BezierSurface : BezierSpline, ParametricSurface
    {
        /// <summary>
        /// point3d[u][v]
        /// </summary>
        private Point3d[][] pointsGrid;

        /// <summary>
        /// The points index example is as following.
        /// The reason for this setting is to look at the coordinate like points[x][y].
        /// As a result, The number of U count is 3 and that of V count is 5.
        ///
        ///  3*---7*--11*
        ///    |      |    |
        ///  2*---6*--10*
        ///    |      |    |
        ///  1*---5*---9*
        ///    |      |    |
        ///  0*---4*---8*
        ///
        /// </summary>
        /// <param name="_pointsGrid"></param>
        public BezierSurface(IEnumerable<IEnumerable<IEnumerable<double>>> _pointsGrid)
        {
            List<List<Point3d>> ptss = new List<List<Point3d>>();

            for (int i = 0; i < _pointsGrid.Count(); i++)
            {
                ptss.Add(new List<Point3d>());
                var pts = _pointsGrid.ElementAt(i);

                for (int j = 0; j < pts.Count(); j++)
                {
                    IEnumerable<double> pt = pts.ElementAt(j);

                    Point3d target = new Point3d(pt);
                    ptss.Last().Add(target);
                }
            }
            this.pointsGrid = ptss.Select(n => n.ToArray()).ToArray();
        }

        public double[] ParameterAt(double u, double v)
        {
            // u
            int n = GetUCount() - 1;
            // v
            int m = GetVCount() - 1;

            Point3d accumulation = new Point3d(0, 0, 0);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    BasisInfo info1 = new BezierBasisInfo(n, i);
                    BasisInfo info2 = new BezierBasisInfo(m, j);

                    Func<double, double> basis1 = GetBasisFunction(info1);
                    Func<double, double> basis2 = GetBasisFunction(info2);
                    Point3d pt = this.pointsGrid[i][j];

                    accumulation += pt * basis1(u) * basis2(v);
                }
            }

            return new double[] { accumulation.X, accumulation.Y, accumulation.Z };
        }

        public int GetUCount()
        {
            return pointsGrid.Length;
        }

        public int GetVCount()
        {
            return pointsGrid[0].Length;
        }

    }
}
