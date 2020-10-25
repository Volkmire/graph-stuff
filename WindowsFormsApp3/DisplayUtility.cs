using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class DisplayUtility
    {
        public static void display_message(string message)
        {
            MessageBox.Show(message);
        }

        public static void draw_node(Graphics graphics, NodePoint node, int radius, bool is_terminal, bool is_activated)
        {
            Pen pen;
            Brush brush;
            NodePoint point;

            pen = new Pen(Color.Black, 2);
            point = NodePoint.adjust_center(node.X, node.Y);
            graphics.DrawEllipse(pen, point.X, point.Y, radius, radius);

            if (is_terminal == true)
            {
                brush = new SolidBrush(Color.Green);
                graphics.FillEllipse(brush, point.X, point.Y, radius, radius);
            }
            else if (is_activated == true)
            {
                brush = new SolidBrush(Color.Red);
                graphics.FillEllipse(brush, point.X, point.Y, radius, radius);
            }
        }

        private static void draw_line(NodePoint a, NodePoint b, Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, a.X, a.Y, b.X, b.Y);
        }
        private static void draw_edges(NodePoint node, Graphics graphics, Pen pen)
        {
            foreach (NodePoint current_edge in node.edges)
            {
                draw_line(node, current_edge, graphics, pen);
            }
        }
        private static void draw_path(List<NodePoint> path, Graphics graphics, Pen pen)
        {
            int n;

            n = 1;
            while (n < path.Count)
            {
                draw_line(path[n - 1], path[n], graphics, pen);
                n++;
            }
        }
        public static void draw_graph(Graphics graphics, Pen default_pen, Pen path_pen, Graph graph)
        {
            foreach (NodePoint node in graph.nodes)
            {
                draw_node(graphics, node, NodePoint.node_radius, node.is_terminal, node.is_activated);
                draw_edges(node, graphics, default_pen);
            }
            draw_path(graph.path, graphics, path_pen);
        }
    }
}

