using Spline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Spline.Utils
{
    public class CurveDivider
    {
        public static double[][] Divide(ParametricCurve crv, int divNum)
        {
            List<double[]> rs = new List<double[]>();
            double unit = 1 / (double)divNum;
            
            for (int i = 0; i <= divNum; i++)
            {
                double t = unit * i;
                rs.Add(crv.ParameterAt(t));
            }

            return rs.ToArray();
        }

        public static double[][] GenerateSegments(ParametricCurve crv, int divNum)
        {
            List<double[]> rs = new List<double[]>();
            double[][] pts = Divide(crv, divNum);

            for (int i = 0; i < divNum; i++)
            {
                double[] ln = pts[i].Concat(pts[i + 1]).ToArray();
                rs.Add(ln);
            }

            return rs.ToArray();
        }
    }
}
