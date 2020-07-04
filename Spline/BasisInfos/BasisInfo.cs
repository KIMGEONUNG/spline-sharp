using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.BasisInfos
{
    /// <summary>
    /// BasisInfo empty class
    /// </summary>
    public abstract class BasisInfo : ICloneable
    {
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
