using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Preset
    {
        public static void ConnectPreset(Graph graph)
        {
            int m;
            int n = 0;            

            while (n < graph.Nodes.Count)
            {
                m = n + 1;
                while (m < graph.Nodes.Count)
                {
                    if (MathUtility.GetGreaterCommonDivisor(n + 1, m + 1) != 1)
                    {
                        graph.Nodes[n].AddEdge(graph.Nodes[m]);
                    }
                    m++;
                }
                n++;
            }
        }

        public static void GetPreset(int size, int width, int height, Graph graph)
        {

            NodePoint node;
            int n = 0;
            int numberOfRowCollumns = MathUtility.GetClosestSqrtInteger(size);
            int increment = (Math.Min(width, height) - 2 * NodePoint.Radius) / (numberOfRowCollumns + 1);            
            int x = increment;
            int y;
            int current_row = 0;
            int current_col;

            while (current_row < numberOfRowCollumns)
            {
                current_col = 0;
                y = current_row % 2 == 0 ? increment : increment + increment / 2;
                while (current_col < numberOfRowCollumns)
                {
                    node = new NodePoint(current_col % 2 == 0 ? x : x + increment / 2, y, graph.Nodes.Count);
                    graph.Nodes.Add(node);
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
