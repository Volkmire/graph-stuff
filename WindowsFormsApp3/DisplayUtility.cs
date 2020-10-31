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
        public static void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public static void DrawNode(Graphics graphics, NodePoint node, int radius, bool isTerminal, bool isActivated)
        {
            Brush brush;
            Pen pen = new Pen(Color.Black, 2);            
            NodePoint point = NodePoint.AdjustCenter(node.X, node.Y); ;

            graphics.DrawEllipse(pen, point.X, point.Y, radius, radius);

            if (isTerminal == true)
            {
                brush = new SolidBrush(Color.Green);
                graphics.FillEllipse(brush, point.X, point.Y, radius, radius);
            }
            else if (isActivated == true)
            {
                brush = new SolidBrush(Color.Red);
                graphics.FillEllipse(brush, point.X, point.Y, radius, radius);
            }
            
        }

        private static void DrawLine(NodePoint a, NodePoint b, Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, a.X, a.Y, b.X, b.Y);
        }

        private static void DrawEdges(NodePoint node, Graphics graphics, Pen pen)
        {
            foreach (NodePoint edge in node.Edges)
                DrawLine(node, edge, graphics, pen);
        }
        private static void DrawPath(List<NodePoint> path, Graphics graphics, Pen pen)
        {
            int n;

            n = 1;
            while (n < path.Count)
            {
                DrawLine(path[n - 1], path[n], graphics, pen);
                n++;
            }
        }
        public static void DrawGraph(Graphics graphics, Pen defaultPen, Pen pathPen, Graph graph)
        {
            foreach (NodePoint node in graph.Nodes)
            {
                DrawNode(graphics, node, NodePoint.Radius, node.IsTerminal, node.IsActivated);
                DrawEdges(node, graphics, defaultPen);
            }
            DrawPath(graph.Path, graphics, pathPen);
        }
    }
}

