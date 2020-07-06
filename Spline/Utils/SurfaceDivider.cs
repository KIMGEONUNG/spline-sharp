using Spline.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Spline.Utils
{
    public class SurfaceDivider
    {
        /// <summary>
        /// Generate grid points
        /// </summary>
        public static double[][][] GeneratePointGrid(ParametricSurface srf, int uDiv, int vDiv)
        {
            double[][][] uvMat = GenerateUVGridParameters(uDiv, vDiv);

            var gridPoints = uvMat
                .Select(n => n.Select(m => srf.ParameterAt(m[0], m[1])).ToArray())
                .ToArray();

            return gridPoints;
        }

        /// <summary>
        /// Generate grid line
        /// </summary>
        /// <returns> [x0,y0,z0,x1,y1,z1][]</returns>
        public static double[][] GenerateGridSegment(ParametricSurface srf, int uDiv, int vDiv)
        {
            double[][] result = null;
            List<double[]> ls = new List<double[]>();
            double[][][] gridPoints = GeneratePointGrid(srf, uDiv, vDiv);

            // add vertical segments
            for (int i = 0; i <= uDiv; i++)
            {
                for (int j = 0; j < vDiv; j++)
                {
                    var pt1 = gridPoints[i][j];
                    var pt2 = gridPoints[i][j+1];
                    ls.Add(pt1.Concat(pt2).ToArray());
                }
            }

            // add horizontal segments
            for (int j = 0; j <= vDiv; j++)
            {
                for (int i = 0; i < uDiv; i++)
                {
                    var pt1 = gridPoints[i][j];
                    var pt2 = gridPoints[i+1][j];
                    ls.Add(pt1.Concat(pt2).ToArray());
                }
            }

            result = ls.ToArray();

            return result;
        }

        /// <summary>
        /// Generate uv value matrix
        /// </summary>
        public static double[][][] GenerateUVGridParameters(int uDiv, int vDiv)
        {
            double[][][] result = null;
            var ls = new List<List<List<double>>>();

            double uUnit = 1 / (double)uDiv;
            double vUnit = 1 / (double)vDiv;

            for (int i = 0; i <= uDiv; i++)
            {
                ls.Add(new List<List<double>>());
                for (int j = 0; j <= vDiv; j++)
                {
                    ls.Last().Add(new List<double>() { i * uUnit, j * vUnit });
                }
            }

            result = ls.Select(n => n.Select(m => m.ToArray()).ToArray()).ToArray();

            return result;
        }
    }
}
