using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.BasisInfos
{
    public class BSplineBasisInfo : BezierBasisInfo
    {
        public KnotSet Knots { get; protected set; }

        public BSplineBasisInfo(int n, int i, KnotSet knots) : base(n, i)
        {
            this.Knots = (KnotSet)knots.Clone();
        }
        public override object Clone()
        {
            BSplineBasisInfo clone = (BSplineBasisInfo)this.MemberwiseClone();
            clone.Knots = (KnotSet)this.Knots.Clone();

            return clone;
        }
    }
}
