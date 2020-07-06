using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spline;
using Spline.Utils;
using SplineTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplineTest
{
    [TestClass]
    public class NURBSSurfaceTest
    {
        [TestMethod]
        public void ParameterAt()
        {
            double[][][] ptGrid = null;
            double[][] weights = null;
            double[] r, a;
            double u, v, e;
            NURBSSurface surface = null;
            int uDegree, vDegree;
            KnotSet uKnot, vKnot;

            uDegree = 2;
            vDegree = 3;
            uKnot = KnotSet.CreateToUniform(uDegree, 3);
            vKnot = KnotSet.CreateToUniform(vDegree, 5);
            weights = new double[][]
             {
                    new double[]{ 1, 1, 1, 1, 1, },
                    new double[]{ 1, 2, 2, 2, 1, },
                    new double[]{ 1, 1, 1, 1, 1, },
             };

            ptGrid = new double[][][]
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
            u = 0.5;
            v = 0.6;
            e = 0.0001;
            surface = new NURBSSurface(ptGrid, uKnot, vKnot, uDegree, vDegree, weights);
            r = surface.ParameterAt(u, v);
            a = new double[] { 1.0, 2.299465, 1.033422 };

            Assert.IsTrue(r.SequenceEqual(a, e));


            uDegree = 2;
            vDegree = 3;
            uKnot = KnotSet.CreateToUniform(uDegree, 3);
            vKnot = KnotSet.CreateToUniform(vDegree, 5);
            weights = new double[][]
             {
                    new double[]{ 1, 1, 1, 1, 1, },
                    new double[]{ 1, 1, 1, 1, 1, },
                    new double[]{ 1, 1, 1, 1, 1, },
             };

            ptGrid = new double[][][]
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
            u = 0.3;
            v = 0.4;
            e = 0.0001;
            surface = new NURBSSurface(ptGrid, uKnot, vKnot, uDegree, vDegree, weights);
            r = surface.ParameterAt(u, v);
            a = new double[] { 0.6, 1.696, 1.16312 };

            Assert.IsTrue(r.SequenceEqual(a, e));
        }
    }
}
