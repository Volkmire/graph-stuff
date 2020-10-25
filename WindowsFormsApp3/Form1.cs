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
        private const int default_preset_size = 12;
        private int preset_size;
        private int distance_tolerance;
        public NodePoint point { get; private set; } //deprecated
        public Graph graph;
        private Pen default_pen;
        private Pen path_pen;

        public Form1()
        {
            InitializeComponent();
            node_mode_rb.Checked = true;
            this.point = new NodePoint(-1, -1);
            this.graph = new Graph();
            this.default_pen = new Pen(Color.LightSkyBlue, 2);
            this.path_pen = new Pen(Color.DarkRed, 3);
            this.distance_tolerance = 10;
            this.preset_size = (int)preset_size_up_down.Value;
        }

        private void full_reset()
        {
            this.graph.reset();
        }

        private void draw_edges(NodePoint node, Graphics graphics, Pen pen)
        {
            foreach (NodePoint current_edge in node.edges)
            {
                draw_line(node, current_edge, graphics, pen);
            }
        }

        private void draw_path(List<NodePoint> path, Graphics graphics, Pen pen)
        {
            int n;

            n = 1;
            while (n < path.Count)
            {
                draw_line(path[n - 1], path[n], graphics, pen);
                n++;
            }
        }

        private void redraw_nodes(PaintEventArgs e)
        {
            Graphics graphics;

            graphics = e.Graphics;
            foreach (NodePoint node in this.graph.nodes)
            {
                node.draw(graphics);
                draw_edges(node, graphics, this.default_pen);
            }
            if (this.graph.path.Count != 0)
            {
                draw_path(this.graph.path, graphics, path_pen);
            }
        }

        private void draw_line(NodePoint a, NodePoint b, Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, a.X, a.Y, b.X, b.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.graph.nodes.Count > 0)
            {
                redraw_nodes(e);
            }
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
            NodePoint node;

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
                    node = new NodePoint(current_col % 2 == 0 ? x : x + increment / 2, y, this.graph.nodes.Count);
                    this.graph.add_node(node);
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

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            NodePoint node;
            int index;

            index = get_point_index_on_click(e);
            if (node_mode_rb.Checked)
            {
                if (index >= 0) // there is a node there
                {
                    this.graph.queue_terminal(this.graph.nodes[index]);
                }
                else
                {
                    node = new NodePoint(e.X, e.Y, this.graph.nodes.Count);
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
            this.graph.reset();
            panel1.Invalidate();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            this.graph.reset_edges();
            this.graph.reset_discovered();
            this.graph.path.Clear();
            panel1.Invalidate();
        }

        private void preset_button_Click(object sender, EventArgs e)
        {
            this.full_reset();
            get_preset(preset_size);
            connect_preset();
            panel1.Invalidate();
        }

        private void find_path_button_Click(object sender, EventArgs e)
        {
            this.graph.path = this.graph.find_path();
            panel1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ;
        }

        private void help_button_Click(object sender, EventArgs e)
        {
            string message;

            message = "This is a toy pathfinding program.\n" +
            "To add a node, click the panel in NODE MODE;\n" + 
            "To add an edge, click two nodes in EDGE MODE;\n" + 
            "To remove an edge, click two nodes that have a common edge;\n" +
            "To find a path, select two nodes in NODE MODE and click FIND PATH;\n" +
            "To use a premade graph, click USE PRESET.";

            Utility.display_message(message);
        }

        private void preset_size_up_down_ValueChanged(object sender, EventArgs e)
        {
            this.preset_size = (int)preset_size_up_down.Value;
        }
    }
}
