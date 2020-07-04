using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spline.BasisInfos
{
    public class NURBSBasisInfo : BSplineBasisInfo
    {
        public double[] Weights { get; protected set; }

        public NURBSBasisInfo(int n, int i, KnotSet knots, IEnumerable<double> weights) : base(n, i, knots)
        {
            this.Weights = weights.ToArray();
        }

        public override object Clone()
        {
            NURBSBasisInfo clone = (NURBSBasisInfo)this.MemberwiseClone();
            clone.Knots = (KnotSet)this.Knots.Clone();
            clone.Weights = this.Weights.ToArray();

            return clone;
        }
    }
}
