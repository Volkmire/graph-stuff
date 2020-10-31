using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public static class MathUtility
    {
        public static int GetClosestSqrtInteger(int n)
        {
            return (int)Math.Sqrt(n) + 1;
        }

        public static int GetGreaterCommonDivisor(int a, int b) //a = xb + r
        {
            if (b > a)
                return GetGreaterCommonDivisor(b, a);

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            int r = a % b;

            if (r == 0)
                return b;

            return GetGreaterCommonDivisor(b, r);
        }

        public static double GetDistance(NodePoint p, NodePoint q)
        {
            double dx_squared = Math.Pow((p.X - q.X), 2);
            double dy_squared = Math.Pow((p.Y - q.Y), 2);

            return Math.Sqrt(dx_squared + dy_squared);
        }
    }
}
