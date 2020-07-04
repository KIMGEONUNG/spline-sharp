using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.BasisInfos
{
    public class BezierBasisInfo : BasisInfo
    {
        public int N { get; protected set; }
        public int I { get; protected set; }

        public BezierBasisInfo(int n, int i)
        {
            N = n;
            I = i;
        }
    }
}
