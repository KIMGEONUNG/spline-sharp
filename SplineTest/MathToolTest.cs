using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplineTest
{
    [TestClass]
    public class MathToolTest 
    {
        [TestMethod]
        public void GetFactorial()
        {
            int i;
            int r, a;

            i = 0;
            r = MathTool.GetFactorial(i);
            a= 1;
            Assert.IsTrue(r == a);

            i = 4;
            r = MathTool.GetFactorial(i);
            a= 24;
            Assert.IsTrue(r == a);

            i = -2;
            Assert.ThrowsException<ArgumentException>(() => MathTool.GetFactorial(i));
        }

        [TestMethod]
        public void GetBinomialCoefficient()
        {
            int n, i,a,r;

            n = 3;
            i = 2;
            r = MathTool.GetBinomialCoefficient(n, i);
            a = 3;
            Assert.IsTrue(a == r);

            n = -1;
            i = 2;
            Assert.ThrowsException<ArgumentException>(() => MathTool.GetBinomialCoefficient(n, i));

            n = 2;
            i = -2;
            Assert.ThrowsException<ArgumentException>(() => MathTool.GetBinomialCoefficient(n, i));
        }
    }
}
