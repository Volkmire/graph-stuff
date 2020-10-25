using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Preset
    {
        public static void connect_preset(Graph graph)
        {
            int n;
            int m;

            n = 0;
            while (n < graph.nodes.Count)
            {
                m = n + 1;
                while (m < graph.nodes.Count)
                {
                    if (MathUtility.gcd(n + 1, m + 1) != 1)
                    {
                        graph.nodes[n].add_edge(graph.nodes[m]);
                    }
                    m++;
                }
                n++;
            }
        }

        public static void get_preset(int size, int width, int height, Graph graph)
        {
            int n;
            int x;
            int y;
            int increment;
            int number_of_rowcolumns;
            int current_row;
            int current_col;
            NodePoint node;

            number_of_rowcolumns = MathUtility.get_closest_int_sqrt(size);
            n = 0;
            current_row = 0;
            increment = (Math.Min(width, height) - 2 * NodePoint.node_radius) / (number_of_rowcolumns + 1);
            x = increment;
            while (current_row < number_of_rowcolumns)
            {
                current_col = 0;
                y = current_row % 2 == 0 ? increment : increment + increment / 2;
                while (current_col < number_of_rowcolumns)
                {
                    node = new NodePoint(current_col % 2 == 0 ? x : x + increment / 2, y, graph.nodes.Count);
                    graph.nodes.Add(node);
                    y += increment;
                    current_col += 1;

                    n++;
                    if (n >= size)
                        return;
                }
                current_row += 1;
                x += increment;
            }
        }
    }
}
