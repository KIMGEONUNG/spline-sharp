using Spline.BasisInfos;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    public class NURBSCurve : NURBS
    {
        protected Point3d[] points;
        protected KnotSet knotVector;
        protected int degree;
        private double[] weights;

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
            Point3d result = new Point3d(0, 0, 0);

            int n = points.Length - 1;

            for (int i = 0; i <= n; i++)
            {
                Point3d pt = points[i];

                BasisInfo info = new NURBSBasisInfo(i, degree, knotVector, weights);
                var basis = GetBasisFunction(info);
                double val = basis(t);

                result = result + val * pt;
            }
            return new double[] { result.X, result.Y, result.Z };
        }
    }
}
