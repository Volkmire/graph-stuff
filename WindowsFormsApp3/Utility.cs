using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class Utility
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

        public static void enqueue_list_content<T>(Queue<T> queue, List<T> list)
        {
            foreach (T item in list)
            {
                queue.Enqueue(item);
            }
        }

        public static void display_message(string message)
        {
            MessageBox.Show(message);
        }
    }
}
