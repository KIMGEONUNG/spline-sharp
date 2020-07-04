using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplineTest.Utils
{
    public static class Extensions
    {
        public static bool SequenceEqual(this IEnumerable<float> data, IEnumerable<float> target, double epsilon)
        {
            if (data.Count() != target.Count())
            {
                return false;
            }

            var zips = data.Zip(target);

            foreach ((double First, double Second) item in zips)
            {
                double a = item.First;
                double b = item.Second;

                if (Math.Abs(a - b) > epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool SequenceEqual(this IEnumerable<double> data, IEnumerable<double> target, double epsilon)
        {
            if (data.Count() != target.Count())
            {
                return false;
            }

            var zips = data.Zip(target);

            foreach ((double First, double Second) item in zips)
            {
                double a = item.First;
                double b = item.Second;

                if (Math.Abs(a - b) > epsilon)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
