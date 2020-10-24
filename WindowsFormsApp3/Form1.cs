using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int distance_tolerance;

        public NodePoint point { get; private set; } //deprecated
        //public List<NodePoint> points;
        //public List<NodePoint> current_selection;
        public Graph graph;
        private Pen default_pen;

        public Form1()
        {
            InitializeComponent();
            node_mode_rb.Checked = true;
            this.point = new NodePoint(-1, -1);
            //this.points = new List<NodePoint>();
            //this.current_selection = new List<NodePoint>();
            this.graph = new Graph();
            this.default_pen = new Pen(Color.LightSkyBlue, 2);
            this.distance_tolerance = 10;
        }

        private void draw_edges(NodePoint node, Graphics graphics)
        {
            foreach (NodePoint current_edge in node.edges)
            {
                draw_line(node, current_edge, graphics);
            }
        }

        private void redraw_nodes(PaintEventArgs e)
        {
            Graphics graphics;

            graphics = e.Graphics;
            foreach (NodePoint node in this.graph.nodes)
            {
                node.draw(graphics);
                draw_edges(node, graphics);
            }
        }

        private void draw_line(NodePoint a, NodePoint b, Graphics graphics)
        {
            graphics.DrawLine(this.default_pen, a.X, a.Y, b.X, b.Y);
        }

        private int get_point_index_on_click(MouseEventArgs e)
        {
            NodePoint clicked_point;
            double distance;
            int index;

            index = 0;
            clicked_point = new NodePoint(e.X, e.Y);
            while (index < this.graph.nodes.Count)
            {
                distance = NodePoint.get_distance(this.graph.nodes[index], clicked_point);
                if (distance < distance_tolerance)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void connect_preset()
        {
            int n;
            int m;

            n = 0;
            while (n < this.graph.nodes.Count)
            {
                m = n + 1;
                while (m < this.graph.nodes.Count)
                {
                    if (Utility.gcd(n + 1, m + 1) != 1)
                    {
                        //MessageBox.Show(n.ToString() + m.ToString());
                        this.graph.nodes[n].add_edge(this.graph.nodes[m]);
                    }
                    m++;
                }
                n++;
            }
        }

        private void get_preset(int size)
        {
            int n;
            int x;
            int y;
            int increment;
            int number_of_rowcolumns;
            int current_row;
            int current_col;

            number_of_rowcolumns = Utility.get_closest_int_sqrt(size);
            n = 0;
            current_row = 0;
            increment = (Math.Min(panel1.Width, panel1.Height) - 2 * NodePoint.node_radius) / (number_of_rowcolumns + 1);
            x = increment;
            while (current_row < number_of_rowcolumns)
            {
                current_col = 0;
                y = current_row % 2 == 0 ? increment : increment + increment / 2;
                while (current_col < number_of_rowcolumns)
                {
                    this.graph.add_node(new NodePoint(current_col % 2 == 0 ? x : x + increment / 2, y));
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.graph.nodes.Count > 0)
            {
                redraw_nodes(e);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            NodePoint node;
            int index;

            index = get_point_index_on_click(e);
            if (node_mode_rb.Checked)
            {
                if (index >= 0) // there is a point there
                {
                    this.graph.queue_terminal(this.graph.nodes[index]);
                }
                else
                {
                    node = new NodePoint(e.X, e.Y);
                    this.graph.add_node(node);
                }
                panel1.Invalidate();
            }
            else
            {
                if (index < 0)
                    return;

                node = this.graph.nodes[index];
                node.toggle();

                this.graph.add_to_selection(node);
                this.graph.process_selection();

                panel1.Invalidate();
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            this.graph.clear();
            panel1.Invalidate();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            this.graph.reset_edges();
            panel1.Invalidate();
        }

        private void preset_button_Click(object sender, EventArgs e)
        {
            this.graph.clear();
            get_preset(15);
            connect_preset();
            panel1.Invalidate();
        }
    }
}
