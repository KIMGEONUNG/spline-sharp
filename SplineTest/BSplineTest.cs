using Spline;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Linq;

namespace SplineTest
{
    [TestClass]
    public class BSplineTest
    {
        [TestMethod]
        public void BSpline()
        {
            double[][] pts = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            BSpline bSpline = null; 

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSpline(pts, knotset, degree);
        }

        [TestMethod]
        public void GetPoint()
        {
            double[][] pts = null;
            KnotSet knotset = null;
            int degree = int.MinValue;
            BSpline bSpline = null;
            double[] r, a;
            double t;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 2,4,0},
                    new double[]{ 4,0,0},
                    new double[]{ 6,4,0},
                };
            knotset = new KnotSet(new double[] { 0, 0, 0, 0, 1, 1, 1, 1 });
            degree = 3;
            bSpline = new BSpline(pts, knotset, degree);
            t = 0.5;
            a = new double[] { 3, 2, 0 };
            r = bSpline.GetPoint(t);

            Assert.IsTrue(a.SequenceEqual(r));
        }
    }
}
