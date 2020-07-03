using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Spline.Utils;

namespace SplineTest
{
    [TestClass]
    public class KnotSetTest 
    {
        [TestMethod]
        public void GetIndexOf()
        {
            double[] knots = null;
            KnotSet knotSet = null;
            double r;
            double a;

            knots = new double[] { 1, 2, 3, 4 };
            knotSet = new KnotSet(knots);
            r = knotSet.GetIndexOf(1);
            a = 2;
            Assert.IsTrue(r == a);

            knots = new double[] { 1, 2, 3, 4 };
            knotSet = new KnotSet(knots);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => knotSet.GetIndexOf(-1));

            knots = new double[] { 1, 2, 3, 4 };
            knotSet = new KnotSet(knots);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => knotSet.GetIndexOf(5));

            knots = new double[] { 1, 2, 3, 4 };
            knotSet = new KnotSet(knots, false);
            r = knotSet.GetIndexOf(-1);
            a = 1;
            Assert.IsTrue(r == a);

            knots = new double[] { 1, 2, 3, 4 };
            knotSet = new KnotSet(knots, false);
            r = knotSet.GetIndexOf(7);
            a = 4;
            Assert.IsTrue(r == a);
        }

        [TestMethod]
        public void IsValid()
        {
            double[] knots = null;
            KnotSet knotSet = null;
            bool r;
            bool a;

            knots = new double[] { 1, 0, 3, 4 };
            knotSet = new KnotSet(knots);
            r = false;
            a = knotSet.IsValid();

            Assert.IsTrue(r == a);

            knots = new double[] { 1, 2, 3, 2 };
            knotSet = new KnotSet(knots);
            r = false;
            a = knotSet.IsValid();

            Assert.IsTrue(r == a);

            knots = new double[] { 1, 1, 3, 3 };
            knotSet = new KnotSet(knots);
            r = true;
            a = knotSet.IsValid();

            Assert.IsTrue(r == a);
        }

        [TestMethod]
        public void GetKnotArray()
        {
            double[] knots = null;
            KnotSet knotSet = null;
            double[] r;
            double[] a;

            knots = new double[] { 1, 2, 3, 2 };
            knotSet = new KnotSet(knots);

            r = knotSet.GetKnotArray();
            a = new double[] { 1, 2, 3, 2 };

            Assert.IsTrue(r.SequenceEqual(a));
        }

        [TestMethod]
        public void CreateToUniform()
        {
            KnotSet knotSet = null;
            int degree = int.MinValue;
            int numControlPoints = int.MinValue;
            double[] r = null;
            double[] a = null ;

            numControlPoints = 3;
            degree = 2;
            knotSet = KnotSet.CreateToUniform(degree, numControlPoints);
            r = knotSet.GetKnotArray();
            a = new double[] { 0, 0, 0, 1, 1, 1 };

            Assert.IsTrue(r.SequenceEqual(a));


            numControlPoints = 4;
            degree = 2;
            knotSet = KnotSet.CreateToUniform(degree, numControlPoints);
            r = knotSet.GetKnotArray();
            a = new double[] { 0, 0, 0, 0.5, 1, 1, 1 };

            Assert.IsTrue(r.SequenceEqual(a));


            numControlPoints = 8;
            degree = 3;
            knotSet = KnotSet.CreateToUniform(degree, numControlPoints);
            r = knotSet.GetKnotArray();
            a = new double[] { 0, 0, 0, 0, 0.2, 0.4, 0.6, 0.8, 1, 1, 1, 1 };

            Assert.IsTrue(r.SequenceEqual(a));
        }
    }
}
