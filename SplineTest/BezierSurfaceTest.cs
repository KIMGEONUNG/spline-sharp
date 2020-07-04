using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spline;
using SplineTest.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplineTest
{
    [TestClass]
    public class BezierSurfaceTest
    {
        [TestMethod]
        public void GetUCount()
        {
            double[][][] ptGrid = null;
            double r, a;
            BezierSurface surface = null;

            ptGrid = new double[][][]
             {
                 new double[][]
                 {
new double[]  {0.0, 0.0, 0.0} ,
new double[] { 0.0, 1.0, 2.0} ,
new double[] { 0.0, 2.0, 1.0} ,
new double[] { 0.0, 3.0, 0.0} ,
                },
                new double[][]
                {
new double[] { 1.0, 0.0, 2.0} ,
new double[] { 1.0, 1.0, 0.0} ,
new double[] { 1.0, 2.0, 2.0} ,
new double[] { 1.0, 3.0, 1.0} ,
                },
                new double[][]
                {
new double[] { 2.0, 0.0, 1.0} ,
new double[] { 2.0, 1.0, 0.0} ,
new double[] { 2.0, 2.0, 2.0} ,
new double[] { 2.0, 3.0, 0.0} ,
                 },
             };
            surface = new BezierSurface(ptGrid);
            r = surface.GetUCount();
            a = 3;

            Assert.IsTrue(r == a);
        }

        [TestMethod]
        public void GetVCount()
        {
            double[][][] ptGrid = null;
            double r, a;
            BezierSurface surface = null;

            ptGrid = new double[][][]
             {
                 new double[][]
                 {
new double[]  {0.0, 0.0, 0.0} ,
new double[] { 0.0, 1.0, 2.0} ,
new double[] { 0.0, 2.0, 1.0} ,
new double[] { 0.0, 3.0, 0.0} ,
                },
                new double[][]
                {
new double[] { 1.0, 0.0, 2.0} ,
new double[] { 1.0, 1.0, 0.0} ,
new double[] { 1.0, 2.0, 2.0} ,
new double[] { 1.0, 3.0, 1.0} ,
                },
                new double[][]
                {
new double[] { 2.0, 0.0, 1.0} ,
new double[] { 2.0, 1.0, 0.0} ,
new double[] { 2.0, 2.0, 2.0} ,
new double[] { 2.0, 3.0, 0.0} ,
                 },
             };
            surface = new BezierSurface(ptGrid);
            r = surface.GetVCount();
            a = 4;

            Assert.IsTrue(r == a);
        }

        [TestMethod]
        public void ParameterAt()
        {
            double[][][] ptGrid = null;
            double[] r, a;
            double u, v, e;
            BezierSurface surface = null;


            ptGrid = new double[][][]
             {
                 new double[][]
                 {
new double[]  {0.0, 0.0, 0.0} ,
new double[] { 0.0, 1.0, 2.0} ,
new double[] { 0.0, 2.0, 1.0} ,
new double[] { 0.0, 3.0, 0.0} ,
                },
                new double[][]
                {
new double[] { 1.0, 0.0, 2.0} ,
new double[] { 1.0, 1.0, 0.0} ,
new double[] { 1.0, 2.0, 2.0} ,
new double[] { 1.0, 3.0, 1.0} ,
                },
                new double[][]
                {
new double[] { 2.0, 0.0, 1.0} ,
new double[] { 2.0, 1.0, 0.0} ,
new double[] { 2.0, 2.0, 2.0} ,
new double[] { 2.0, 3.0, 0.0} ,
                 },
             };
            u = 0.3;
            v = 0.4;
            e = 0.0001;
            surface = new BezierSurface(ptGrid);
            r = surface.ParameterAt(u, v);
            a = new double[] { 0.6, 1.2, 1.086 };

            Assert.IsTrue(r.SequenceEqual(a, e));


            ptGrid = new double[][][]
             {
                 new double[][]
                 {
new double[]  {0.0, 0.0, 0.0} ,
new double[] { 0.0, 1.0, 2.0} ,
new double[] { 0.0, 2.0, 1.0} ,
new double[] { 0.0, 3.0, 0.0} ,
                },
                new double[][]
                {
new double[] { 1.0, 0.0, 2.0} ,
new double[] { 1.0, 1.0, 0.0} ,
new double[] { 1.0, 2.0, 2.0} ,
new double[] { 1.0, 3.0, 1.0} ,
                },
                new double[][]
                {
new double[] { 2.0, 0.0, 1.0} ,
new double[] { 2.0, 1.0, 0.0} ,
new double[] { 2.0, 2.0, 2.0} ,
new double[] { 2.0, 3.0, 0.0} ,
                 },
             };
            u = 0.8;
            v = 0.9;
            e = 0.0001;
            surface = new BezierSurface(ptGrid);
            r = surface.ParameterAt(u, v);
            a = new double[] { 1.6, 2.7, 0.713 };

            Assert.IsTrue(r.SequenceEqual(a, e));


            ptGrid = new double[][][]
             {
                 new double[][]
                 {
new double[]  {0.0, 0.0, 0.0} ,
new double[] { 0.0, 1.0, 2.0} ,
new double[] { 0.0, 2.0, 1.0} ,
new double[] { 0.0, 3.0, 0.0} ,
                },
                new double[][]
                {
new double[] { 1.0, 0.0, 2.0} ,
new double[] { 1.0, 1.0, 0.0} ,
new double[] { 1.0, 2.0, 2.0} ,
new double[] { 1.0, 3.0, 1.0} ,
                },
                new double[][]
                {
new double[] { 2.0, 0.0, 1.0} ,
new double[] { 2.0, 1.0, 0.0} ,
new double[] { 2.0, 2.0, 2.0} ,
new double[] { 2.0, 3.0, 0.0} ,
                 },
             };
            u = 0.1;
            v = 0.2;
            e = 0.0001;
            surface = new BezierSurface(ptGrid);
            r = surface.ParameterAt(u, v);
            a = new double[] { 0.2, 0.6, 0.9272 };

            Assert.IsTrue(r.SequenceEqual(a, e));
        }
    }
}
