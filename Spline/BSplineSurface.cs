using Spline.BasisInfos;
using Spline.Interfaces;
using Spline.Utils;
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
        protected KnotSet uKnotVector;
        protected KnotSet vKnotVector;
        protected int uDegree;
        protected int vDegree;

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
        public BSplineSurface(IEnumerable<IEnumerable<IEnumerable<double>>> _pointsGrid,  KnotSet uKnotVector, KnotSet vKnotVector, int uDegree, int vDegree) 
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

            this.uKnotVector = (KnotSet)uKnotVector.Clone();
            this.vKnotVector = (KnotSet)vKnotVector.Clone();
            this.uDegree = uDegree;
            this.vDegree = vDegree;
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
                BasisInfo info1 = new BSplineBasisInfo(i, uDegree, uKnotVector);
                Func<double, double> basis1 = GetBasisFunction(info1);

                // Boundary condition
                if (u == 1 && i == n)
                {
                    basis1 = (t) => 1;
                }

                for (int j = 0; j <= m; j++)
                {
                    BasisInfo info2 = new BSplineBasisInfo(j, vDegree, vKnotVector);
                    Func<double, double> basis2 = GetBasisFunction(info2);

                    // Boundary condition
                    if (v == 1 && j == m)
                    {
                        basis2 = (t) => 1;
                    }

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
