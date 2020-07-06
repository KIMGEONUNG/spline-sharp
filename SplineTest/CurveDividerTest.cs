using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spline;
using Spline.Utils;
using SplineTest.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplineTest
{
    [TestClass]
    public class CurveDividerTest
    {
        [TestMethod]
        public void Divide()
        {
            double[][] pts = null;
            BezierCurve bezier = null;
            int divNum;
            double t;
            double[][] r, a = null;
            double e;

            divNum = 4;
            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts);
            e = 0.001;

            r = CurveDivider.Divide(bezier, divNum);
            a = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[] {1.5,1.5,0 },
                    new double[] {3,2,0 },
                    new double[] {4.5,1.5,0 },
                    new double[] {6,0,0 },
                };

            Assert.IsTrue(a.Length == r.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.IsTrue(a[i].SequenceEqual(r[i], e));
            }
        }

        [TestMethod]
        public void GenerateSegments()
        {
            double[][] pts = null;
            BezierCurve bezier = null;
            int divNum;
            double t;
            double[][] r, a = null;
            double e;

            divNum = 4;
            pts = new double[][]
                {
                    new double[]{ 0,0,0},
                    new double[]{ 3,4,0},
                    new double[]{ 6,0,0},
                };
            bezier = new BezierCurve(pts);
            e = 0.001;

            r = CurveDivider.GenerateSegments(bezier, divNum);
            a = new double[][]
                {
                    new double[]{ 0,0,0,1.5,1.5,0 },
                    new double[] {1.5,1.5,0 ,3,2,0 },
                    new double[] {3,2,0 ,4.5,1.5,0 },
                    new double[] {4.5,1.5,0 ,6,0,0 },
                };

            Assert.IsTrue(a.Length == r.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.IsTrue(a[i].SequenceEqual(r[i], e));
            }
        }
    }
}
