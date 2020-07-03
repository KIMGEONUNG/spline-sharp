using Spline;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Spline.Enums;

namespace SplineTest
{
    [TestClass]
    public class BezierCurveTest
    {
        [TestMethod]
        public void BezierCurve()
        {
            double[][] pts = null;
            BezierCurve bezier = null; 

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts);
        }

        [TestMethod]
        public void ParameterAt()
        {
            double[][] pts = null;
            BezierCurve bezier = null;
            double t;
            double[] r, a;
            double e;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts, BezierAlgorithms.Recursion);
            t = 0.5;
            a = new double[] { 3, 2, 0 };
            r = bezier.ParameterAt(t);

            Assert.IsTrue(r.SequenceEqual(a));

            
            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts, BezierAlgorithms.BerteinPolynomial);
            t = 0.5;
            a = new double[] { 3, 2, 0 };
            r = bezier.ParameterAt(t);

            Assert.IsTrue(r.SequenceEqual(a));


            pts = new double[][]
               {
                    new double[]{ -4,-4,0},
                    new double[]{ -2,4,0},
                    new double[]{ 2,-4,0},
                    new double[]{ 4, 4,0},
                };
            bezier = new BezierCurve(pts, BezierAlgorithms.Recursion);
            t = 0.3;
            a = new double[] { -1.768, -0.256, 0 };
            r = bezier.ParameterAt(t);
            e = 0.01;

            Assert.IsTrue(r.SequenceEqual(a,e));


            pts = new double[][]
               {
                    new double[]{ -4,-4,0},
                    new double[]{ -2,4,0},
                    new double[]{ 2,-4,0},
                    new double[]{ 4, 4,0},
                };
            bezier = new BezierCurve(pts, BezierAlgorithms.BerteinPolynomial);
            t = 0.3;
            a = new double[] { -1.768, -0.256, 0 };
            r = bezier.ParameterAt(t);
            e = 0.01;

            Assert.IsTrue(r.SequenceEqual(a,e));
        }

        [TestMethod]
        public void GetDegree()
        {
            double[][] pts = null;
            BezierCurve bezier = null;
            int r, a;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts);
            a = 2;
            r = bezier.GetDegree();

            Assert.IsTrue(a == r);
        }

        [TestMethod]
        public void GetOrder()
        {
            double[][] pts = null;
            BezierCurve bezier = null;
            int r, a;

            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts);
            a = 3;
            r = bezier.GetOrder();

            Assert.IsTrue(a == r);
        }
    }
}
