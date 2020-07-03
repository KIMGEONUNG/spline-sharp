using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline
{
    public class NURBSCurve : BSpline
    {
        private double[] weights;

        public NURBSCurve(IEnumerable<IEnumerable<double>> pts, KnotSet knotset, IEnumerable<double> weights, int degree) :base(pts, knotset,degree)
        {
           this.weights = weights.ToArray();
        }

        public override double[] ParameterAt(double t)
        {
            Point3d result = new Point3d(0, 0, 0);

            int n = points.Length - 1;

            for (int i = 0; i <= n; i++)
            {
                Point3d pt = points[i];
                double val = GetRationalBasis(i, degree, this.knotVector, this.weights, t);

                result = result + val * pt;
            }
            return new double[] { result.X, result.Y, result.Z };
        }

        private double GetRationalBasis(int i, int j, KnotSet knots, double[] weight, double t)
        {
            int n = points.Length - 1;

            // Calculate denominator
            double denominator = 0; 
            for (int k = 0; k <= n; k++)
            {
                double val = GetBasis(k,j,knots,t) * weight[k];
                denominator += val;
            }
            
            // Calculate numerator
            double numerator = GetBasis(i,j,knots,t) * weight[i];

            double result = numerator / denominator;

            return result;
        }
    }
}
