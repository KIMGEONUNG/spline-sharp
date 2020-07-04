using Spline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    public class BSplineSurface : BSpline, ParametricSurface
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
        public BSplineSurface(IEnumerable<IEnumerable<IEnumerable<double>>> _pointsGrid, IEnumerable<IEnumerable<double>> knots, int degree)
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
            throw new NotImplementedException();
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
