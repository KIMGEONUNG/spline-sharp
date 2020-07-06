using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spline;
using Spline.Interfaces;
using Spline.Utils;
using SplineTest.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplineTest
{
    [TestClass]
    public class SurfaceDividerTest
    {
        [TestMethod]
        public void GenerateUVGridParameters()
        {
            double[][][] r, a;
            int uDiv, vDiv;
            double e;

            uDiv = 5;
            vDiv = 2;
            e = 0.0001;

            r = SurfaceDivider.GenerateUVGridParameters(uDiv, vDiv);
            a = new double[][][]
                {
                    new double[][]{
                    new double[] {0 ,0 },
                    new double[] {0 , 0.5},
                    new double[] {0 , 1},
                    },
                    new double[][]{
                    new double[] {0.2 ,0 },
                    new double[] {0.2 , 0.5},
                    new double[] {0.2 , 1},
                    },
                    new double[][]{
                    new double[] {0.4 ,0 },
                    new double[] {0.4 , 0.5},
                    new double[] {0.4 , 1},
                    },
                    new double[][]{
                    new double[] {0.6 ,0 },
                    new double[] {0.6 , 0.5},
                    new double[] {0.6 , 1},
                    },
                    new double[][]{
                    new double[] {0.8 ,0 },
                    new double[] {0.8 , 0.5},
                    new double[] {0.8 , 1},
                    },
                    new double[][]{
                    new double[] {1.0 ,0 },
                    new double[] {1.0 , 0.5},
                    new double[] {1.0 , 1},
                    },
                };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsTrue(a[i][j].SequenceEqual(r[i][j], e));
                }
            }
        }

        [TestMethod]
        public void GeneratePointGrid()
        {
            double[][][] pts, r, a = null;
            ParametricSurface srf;
            int uCount, vCount;
            double e;

            e = 0.0001;

            pts = new double[][][]
                {
                    new double[][]{
new double[] {0.0, 0.0, 1.0 },
new double[] {0.0, 1.0, 2.0 },
new double[] {0.0, 2.0, 0.0 },
new double[] {0.0, 3.0, 1.0 },
new double[] {0.0, 4.0, 1.0 },
                    },
                    new double[][]{
new double[] {1.0, 0.0, 2.0 },
new double[] {1.0, 1.0, 2.0 },
new double[] {1.0, 2.0, 1.0 },
new double[] {1.0, 3.0, 1.0 },
new double[] {1.0, 4.0, 1.0 },
                    },
                    new double[][]{
new double[] {2.0, 0.0, 2.0 },
new double[] {2.0, 1.0, 1.0 },
new double[] {2.0, 2.0, 1.0 },
new double[] {2.0, 3.0, 1.0 },
new double[] {2.0, 4.0, 2.0 },
                    },
                };

            srf = new BezierSurface(pts);
            uCount = 10;
            vCount = 4;
            r = SurfaceDivider.GeneratePointGrid(srf, uCount, vCount);
            a = new double[][][] {
                    new double[][]{
       new double[] { 0.0, 0.0, 1.0},
       new double[] { 0.0, 1.0, 1.210938},
       new double[] { 0.0, 2.0, 0.875},
       new double[] { 0.0, 3.0, 0.835938},
       new double[] { 0.0, 4.0, 1.0},

                    },
                    new double[][]{
       new double[] { 0.2, 0.0, 1.19},
       new double[] { 0.2, 1.0, 1.306953},
       new double[] { 0.2, 2.0, 0.95625},
       new double[] { 0.2, 3.0, 0.879453},
       new double[] { 0.2, 4.0, 1.01},

                    },
                    new double[][]{
       new double[] { 0.4, 0.0, 1.36},
       new double[] { 0.4, 1.0, 1.384063},
       new double[] { 0.4, 2.0, 1.025},
       new double[] { 0.4, 3.0, 0.924063},
       new double[] { 0.4, 4.0, 1.04},

                    },
                    new double[][]{
       new double[] { 0.6, 0.0, 1.51},
       new double[] { 0.6, 1.0, 1.442266},
       new double[] { 0.6, 2.0, 1.08125},
       new double[] { 0.6, 3.0, 0.969766},
       new double[] { 0.6, 4.0, 1.09},

                    },
                    new double[][]{
       new double[] { 0.8, 0.0, 1.64},
       new double[] { 0.8, 1.0, 1.481563},
       new double[] { 0.8, 2.0, 1.125},
       new double[] { 0.8, 3.0, 1.016562},
       new double[] { 0.8, 4.0, 1.16},

                    },
                    new double[][]{
       new double[] { 1.0, 0.0, 1.75},
       new double[] { 1.0, 1.0, 1.501953},
       new double[] { 1.0, 2.0, 1.15625},
       new double[] { 1.0, 3.0, 1.064453},
       new double[] { 1.0, 4.0, 1.25},

                    },
                    new double[][]{
       new double[] { 1.2, 0.0, 1.84},
       new double[] { 1.2, 1.0, 1.503438},
       new double[] { 1.2, 2.0, 1.175},
       new double[] { 1.2, 3.0, 1.113437},
       new double[] { 1.2, 4.0, 1.36},

                    },
                    new double[][]{
       new double[] { 1.4, 0.0, 1.91},
       new double[] { 1.4, 1.0, 1.486016},
       new double[] { 1.4, 2.0, 1.18125},
       new double[] { 1.4, 3.0, 1.163516},
       new double[] { 1.4, 4.0, 1.49},

                    },
                    new double[][]{
       new double[] { 1.6, 0.0, 1.96},
       new double[] { 1.6, 1.0, 1.449687},
       new double[] { 1.6, 2.0, 1.175},
       new double[] { 1.6, 3.0, 1.214688},
       new double[] { 1.6, 4.0, 1.64},

                    },
                    new double[][]{
       new double[] { 1.8, 0.0, 1.99},
       new double[] { 1.8, 1.0, 1.394453},
       new double[] { 1.8, 2.0, 1.15625},
       new double[] { 1.8, 3.0, 1.266953},
       new double[] { 1.8, 4.0, 1.81},

                    },
                    new double[][]{
       new double[] { 2.0, 0.0, 2.0},
       new double[] { 2.0, 1.0, 1.320313},
       new double[] { 2.0, 2.0, 1.125},
       new double[] { 2.0, 3.0, 1.320313},
       new double[] { 2.0, 4.0, 2.0},
                    },
                };

            for (int i = 0; i < r.Length; i++)
            {
                for (int j = 0; j < r[0].Length; j++)
                {
                    Assert.IsTrue(r[i][j].SequenceEqual(a[i][j], e));
                }
            }
        }

        [TestMethod]
        public void GenerateGridSegment()
        {
            double[][][] pts;
            double [][] r, a = null;
            ParametricSurface srf;
            int uCount, vCount;
            double e;

            e = 0.0001;

            pts = new double[][][]
                {
                    new double[][]{
new double[] {0.0, 0.0, 1.0 },
new double[] {0.0, 1.0, 2.0 },
new double[] {0.0, 2.0, 0.0 },
new double[] {0.0, 3.0, 1.0 },
new double[] {0.0, 4.0, 1.0 },
                    },
                    new double[][]{
new double[] {1.0, 0.0, 2.0 },
new double[] {1.0, 1.0, 2.0 },
new double[] {1.0, 2.0, 1.0 },
new double[] {1.0, 3.0, 1.0 },
new double[] {1.0, 4.0, 1.0 },
                    },
                    new double[][]{
new double[] {2.0, 0.0, 2.0 },
new double[] {2.0, 1.0, 1.0 },
new double[] {2.0, 2.0, 1.0 },
new double[] {2.0, 3.0, 1.0 },
new double[] {2.0, 4.0, 2.0 },
                    },
                };

            srf = new BezierSurface(pts);
            uCount = 10;
            vCount = 4;
            r = SurfaceDivider.GenerateGridSegment(srf, uCount, vCount);
            a = new double[][] {

new double[] {0,0,1,0,1,1.2109375 },
new double[] {0,1,1.2109375,0,2,0.875 },
new double[] {0,2,0.875,0,3,0.8359375 },
new double[] {0,3,0.8359375,0,4,1 },
new double[] {0.2,0,1.19,0.2,1,1.306953125 },
new double[] {0.2,1,1.306953125,0.2,2,0.95625 },
new double[] {0.2,2,0.95625,0.2,3,0.879453125 },
new double[] {0.2,3,0.879453125,0.2,4,1.01 },
new double[] {0.4,0,1.36,0.4,1,1.3840625 },
new double[] {0.4,1,1.3840625,0.4,2,1.025 },
new double[] {0.4,2,1.025,0.4,3,0.9240625 },
new double[] {0.4,3,0.9240625,0.4,4,1.04 },
new double[] {0.6,0,1.51,0.6,1,1.442265625 },
new double[] {0.6,1,1.442265625,0.6,2,1.08125 },
new double[] {0.6,2,1.08125,0.6,3,0.969765625 },
new double[] {0.6,3,0.969765625,0.6,4,1.09 },
new double[] {0.8,0,1.64,0.8,1,1.4815625 },
new double[] {0.8,1,1.4815625,0.8,2,1.125 },
new double[] {0.8,2,1.125,0.8,3,1.0165625 },
new double[] {0.8,3,1.0165625,0.8,4,1.16 },
new double[] {1,0,1.75,1,1,1.501953125 },
new double[] {1,1,1.501953125,1,2,1.15625 },
new double[] {1,2,1.15625,1,3,1.064453125 },
new double[] {1,3,1.064453125,1,4,1.25 },
new double[] {1.2,0,1.84,1.2,1,1.5034375 },
new double[] {1.2,1,1.5034375,1.2,2,1.175 },
new double[] {1.2,2,1.175,1.2,3,1.1134375 },
new double[] {1.2,3,1.1134375,1.2,4,1.36 },
new double[] {1.4,0,1.91,1.4,1,1.486015625 },
new double[] {1.4,1,1.486015625,1.4,2,1.18125 },
new double[] {1.4,2,1.18125,1.4,3,1.163515625 },
new double[] {1.4,3,1.163515625,1.4,4,1.49 },
new double[] {1.6,0,1.96,1.6,1,1.4496875 },
new double[] {1.6,1,1.4496875,1.6,2,1.175 },
new double[] {1.6,2,1.175,1.6,3,1.2146875 },
new double[] {1.6,3,1.2146875,1.6,4,1.64 },
new double[] {1.8,0,1.99,1.8,1,1.394453125 },
new double[] {1.8,1,1.394453125,1.8,2,1.15625 },
new double[] {1.8,2,1.15625,1.8,3,1.266953125 },
new double[] {1.8,3,1.266953125,1.8,4,1.81 },
new double[] {2,0,2,2,1,1.3203125 },
new double[] {2,1,1.3203125,2,2,1.125 },
new double[] {2,2,1.125,2,3,1.3203125 },
new double[] {2,3,1.3203125,2,4,2 },
new double[] {0,0,1,0.2,0,1.19 },
new double[] {0.2,0,1.19,0.4,0,1.36 },
new double[] {0.4,0,1.36,0.6,0,1.51 },
new double[] {0.6,0,1.51,0.8,0,1.64 },
new double[] {0.8,0,1.64,1,0,1.75 },
new double[] {1,0,1.75,1.2,0,1.84 },
new double[] {1.2,0,1.84,1.4,0,1.91 },
new double[] {1.4,0,1.91,1.6,0,1.96 },
new double[] {1.6,0,1.96,1.8,0,1.99 },
new double[] {1.8,0,1.99,2,0,2 },
new double[] {0,1,1.2109375,0.2,1,1.306953125 },
new double[] {0.2,1,1.306953125,0.4,1,1.3840625 },
new double[] {0.4,1,1.3840625,0.6,1,1.442265625 },
new double[] {0.6,1,1.442265625,0.8,1,1.4815625 },
new double[] {0.8,1,1.4815625,1,1,1.501953125 },
new double[] {1,1,1.501953125,1.2,1,1.5034375 },
new double[] {1.2,1,1.5034375,1.4,1,1.486015625 },
new double[] {1.4,1,1.486015625,1.6,1,1.4496875 },
new double[] {1.6,1,1.4496875,1.8,1,1.394453125 },
new double[] {1.8,1,1.394453125,2,1,1.3203125 },
new double[] {0,2,0.875,0.2,2,0.95625 },
new double[] {0.2,2,0.95625,0.4,2,1.025 },
new double[] {0.4,2,1.025,0.6,2,1.08125 },
new double[] {0.6,2,1.08125,0.8,2,1.125},
new double[] {0.8,2,1.125,1,2,1.15625},
new double[] {1,2,1.15625,1.2,2,1.175},
new double[] {1.2,2,1.175,1.4,2,1.18125},
new double[] {1.4,2,1.18125,1.6,2,1.175},
new double[] {1.6,2,1.175,1.8,2,1.15625},
new double[] {1.8,2,1.15625,2,2,1.125},
new double[] {0,3,0.8359375,0.2,3,0.879453125},
new double[] {0.2,3,0.879453125,0.4,3,0.9240625},
new double[] {0.4,3,0.9240625,0.6,3,0.969765625},
new double[] {0.6,3,0.969765625,0.8,3,1.0165625},
new double[] {0.8,3,1.0165625,1,3,1.064453125},
new double[] {1,3,1.064453125,1.2,3,1.1134375},
new double[] {1.2,3,1.1134375,1.4,3,1.163515625 },
new double[] {1.4,3,1.163515625,1.6,3,1.2146875 },
new double[] {1.6,3,1.2146875,1.8,3,1.266953125 },
new double[] {1.8,3,1.266953125,2,3,1.3203125 },
new double[] {0,4,1,0.2,4,1.01 },
new double[] {0.2,4,1.01,0.4,4,1.04 },
new double[] {0.4,4,1.04,0.6,4,1.09 },
new double[] {0.6,4,1.09,0.8,4,1.16 },
new double[] {0.8,4,1.16,1,4,1.25 },
new double[] {1,4,1.25,1.2,4,1.36 },
new double[] {1.2,4,1.36,1.4,4,1.49 },
new double[] {1.4,4,1.49,1.6,4,1.64 },
new double[] {1.6,4,1.64,1.8,4,1.81 },
new double[] {1.8,4,1.81,2,4,2 },

            };

            for (int i = 0; i < r.Length; i++)
            {
                Assert.IsTrue(r[i].SequenceEqual(a[i], e));
            }
        }
    }
}
