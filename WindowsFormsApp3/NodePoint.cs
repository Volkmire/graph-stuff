using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class NodePoint
    {
        public const int node_radius = 10;
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool is_activated { get; private set; }
        public int id { get; private set; }
        public bool is_terminal { get; private set; }

        public NodePoint discovered_via { get; set; }

        public List<NodePoint> edges;

        public NodePoint(int X, int Y, int id = -1)
        {
            this.X = X;
            this.Y = Y;
            this.is_activated = false;
            this.is_terminal = false;
            this.edges = new List<NodePoint>();
            this.discovered_via = null;
            this.id = id;
        }
        public static NodePoint adjust_center(int x, int y)
        {
            return new NodePoint(x - node_radius / 2, y - node_radius / 2);
        }

        public void add_edge(NodePoint node)
        {
            if (this.find_edge(node) == -1)
            {
                this.edges.Add(node);

                node.edges.Add(this); // the graph is undirected for now;
            }
        }
        
        public int find_edge(NodePoint edge)
        {
            int n;

            n = 0;
            while (n < this.edges.Count)
            {
                if (this.edges[n] == edge)
                {
                    return n;
                }
                n++;
            }

            return -1;
        }

        public void remove_edge(NodePoint node)
        {
            this.edges.Remove(node);
            node.edges.Remove(this);
        }

        public void toggle()
        {
            this.is_activated = this.is_activated ? false : true;
        }

        public void toggle_terminal()
        {
            this.is_terminal = this.is_terminal ? false : true;
        }

        public static double get_distance(NodePoint p, NodePoint q)
        {
            double dx_squared;
            double dy_squared;

            dx_squared = Math.Pow((p.X - q.X), 2);
            dy_squared = Math.Pow((p.Y - q.Y), 2);

            return Math.Sqrt(dx_squared + dy_squared);
        }
        public void draw(Graphics graphics)
        {
            Pen pen;
            Brush brush;
            NodePoint point;

            pen = new Pen(Color.Black, 2);
            point = adjust_center(this.X, this.Y);
            graphics.DrawEllipse(pen, point.X, point.Y, node_radius, node_radius);
            
            if (this.is_terminal == true)
            {
                brush = new SolidBrush(Color.Green);
                graphics.FillEllipse(brush, point.X, point.Y, node_radius, node_radius);
            }
            else if (this.is_activated == true)
            {
                brush = new SolidBrush(Color.Red);
                graphics.FillEllipse(brush, point.X, point.Y, node_radius, node_radius);
            }
        }

        public void display()
        {
            MessageBox.Show("NodePoint at " + this.X + ", " + this.Y);
        }
    }

}
