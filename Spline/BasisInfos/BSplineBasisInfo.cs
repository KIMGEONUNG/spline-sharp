using Spline.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.BasisInfos
{
    public class BSplineBasisInfo : BasisInfo
    {
        public int I { get; protected set; }
        public int J { get; protected set; }
        public KnotSet Knots { get; protected set; }

        public BSplineBasisInfo(int i, int j, KnotSet knots) 
        {
            this.I = i;
            this.J = j;
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
