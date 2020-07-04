using Spline;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Linq;
using Spline.Utils;
using SplineTest.Utils;

namespace SplineTest
{
    [TestClass]
    public class BSplineCurveTest
    {
        [TestMethod]
        public void BSplineCurve()
        {
            double[][] pts = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            BSplineCurve bSpline = null; 

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSplineCurve(pts, knotset, degree);
        }

        [TestMethod]
        public void ParameterAt()
        {
            double[][] pts = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            BSplineCurve bSpline = null;
            double[] r, a;
            double t;
            double e;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSplineCurve(pts, knotset, degree);
            t = 0.5;
            a = new double[] { 3, 2, 0 };
            r = bSpline.ParameterAt(t);

            Assert.IsTrue(a.SequenceEqual(r));


            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSplineCurve(pts, knotset, degree);
            t = 0.384;
            a = new double[] { 2.3040000000000003, 1.9750256640000001, 0 };
            r = bSpline.ParameterAt(t);
            e = 0.0001;

            Assert.IsTrue(a.SequenceEqual(r,e));


            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSplineCurve(pts, knotset, degree);
            t = 0.884;
            a = new double[] { 5.304, 2.905969664, 0 };
            r = bSpline.ParameterAt(t);
            e = 0.0001;

            Assert.IsTrue(a.SequenceEqual(r,e));
        }
    }
}
