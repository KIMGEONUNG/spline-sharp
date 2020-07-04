using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.BasisInfos
{
    public class BezierBasisInfo : BasisInfo
    {
        public int N { get; private set; }
        public int I { get; private set; }

        public BezierBasisInfo(int n, int i)
        {
            N = n;
            I = i;
        }
    }
}
