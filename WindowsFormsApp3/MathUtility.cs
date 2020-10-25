using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class MathUtility
    {
        public static int get_closest_int_sqrt(int n)
        {
            return (int)Math.Sqrt(n) + 1;
        }

        public static int gcd(int a, int b) //a = xb + r
        {
            int r;

            if (b > a)
                return gcd(b, a);
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            r = a % b;
            if (r == 0)
                return b;
            return gcd(b, r);
        }
        public static double get_distance(NodePoint p, NodePoint q)
        {
            double dx_squared;
            double dy_squared;

            dx_squared = Math.Pow((p.X - q.X), 2);
            dy_squared = Math.Pow((p.Y - q.Y), 2);

            return Math.Sqrt(dx_squared + dy_squared);
        }
    }
}
