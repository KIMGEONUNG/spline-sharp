using Spline;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Spline.Utils;
using SplineTest.Utils;
using System.ComponentModel;

namespace SplineTest
{
    [TestClass]
    public class NURBSCurveTest
    {
        [TestMethod]
        public void NURBSCurve()
        {
            double[][] pts = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            NURBSCurve bSpline = null;
            double[] weights = null;

            pts = new double[][]
                {
                        new double[]{ 0,0,0},
                        new double[]{ 2,4,0},
                        new double[]{ 4,0,0},
                        new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            weights = new double[] { 1, 1, 1, 1 };
            degree = 3;

            bSpline = new NURBSCurve(pts, knotset, weights, degree);
        }

        [TestMethod]
        public void ParameterAt()
        {
            double[][] pts = null;
            double[] weights = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            NURBSCurve nurbs = null;
            double[] r, a;
            double t, e;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                };

            weights = new double[] { 1, 3, 1 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 1, 1, 1 });
            degree = 2;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 0.5;
            a = new double[] { 2, 3, 0 };
            r = nurbs.ParameterAt(t);

            Assert.IsTrue(a.SequenceEqual(r));


            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                };

            weights = new double[] { 1, 3, 1 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 1, 1, 1 });
            degree = 2;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 1;
            a = new double[] { 4, 0, 0 };
            r = nurbs.ParameterAt(t);
            e = 0.0001;

            Assert.IsTrue(a.SequenceEqual(r, e));


            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 6,4,0},
                };
            weights = new double[] { 1, 1, 1 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 1, 1, 1 });
            degree = 2;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 1;
            a = new double[] { 6, 4, 0 };
            r = nurbs.ParameterAt(t);
            e = 0.0001;

            Assert.IsTrue(a.SequenceEqual(r, e));


            pts = new double[][]
                {
                     new double[] {0.0, 0.0, 0.0},
                     new double[]{4.0, 5.0, 0.0},
                     new double[]{6.0, 1.0, 0.0},
                     new double[]{9.0, 5.0, 0.0},
                     new double[]{11.0, 3.0, 0.0},
                     new double[]{16.0, 4.0, 0.0},
                };

            weights = new double[] { 1, 3, 1, 3, 1, 2 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1d / 3d, 2d / 3d, 1, 1, 1, 1 });
            degree = 3;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 0.3;
            a = new double[] {5.52901, 3.849042, 0.0} ;
            r = nurbs.ParameterAt(t);

            e = 0.0001;
            Assert.IsTrue(Math.Abs(a[0] - r[0]) < e);
            Assert.IsTrue(Math.Abs(a[1] - r[1]) < e);
            Assert.IsTrue(Math.Abs(a[2] - r[2]) < e);


            pts = new double[][]
                {
                     new double[] {0.0, 0.0, 0.0},
                     new double[]{4.0, 5.0, 0.0},
                     new double[]{6.0, 1.0, 0.0},
                     new double[]{9.0, 5.0, 0.0},
                     new double[]{11.0, 3.0, 0.0},
                     new double[]{16.0, 4.0, 0.0},
                };

            weights = new double[] { 1, 3, 1, 3, 1, 2 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1d / 3d, 2d / 3d, 1, 1, 1, 1 });
            degree = 3;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 0.3948;
            a = new double[] {6.9053986159719711, 3.6972003072706183, 0.0} ;
            r = nurbs.ParameterAt(t);

            e = 0.0001;
            Assert.IsTrue(r.SequenceEqual(a, e));


            pts = new double[][]
                {
                     new double[] {0.0, 0.0, 0.0},
                     new double[]{4.0, 5.0, 0.0},
                     new double[]{6.0, 1.0, 0.0},
                     new double[]{9.0, 5.0, 0.0},
                     new double[]{11.0, 3.0, 0.0},
                     new double[]{16.0, 4.0, 0.0},
                };

            weights = new double[] { 1, 3, 1, 3, 1, 2 };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1d / 3d, 2d / 3d, 1, 1, 1, 1 });
            degree = 3;
            nurbs = new NURBSCurve(pts, knotset, weights, degree);
            t = 1;
            a = new double[] { 16, 4, 0 };
            r = nurbs.ParameterAt(t);

            e = 0.0001;
            Assert.IsTrue(r.SequenceEqual(a, e));
        }
    }
}
