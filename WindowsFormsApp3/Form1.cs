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

        private void redraw_nodes(PaintEventArgs e)
        {
            Graphics graphics;

            graphics = e.Graphics;
            DisplayUtility.draw_graph(graphics, this.default_pen, this.path_pen, this.graph);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.graph.nodes.Count > 0)
            {
                redraw_nodes(e);
            }
        }

        private int get_node_index_on_click(MouseEventArgs e)
        {
            NodePoint clicked_point;
            double distance;
            int index;

            index = 0;
            clicked_point = new NodePoint(e.X, e.Y);
            while (index < this.graph.nodes.Count)
            {
                distance = MathUtility.get_distance(this.graph.nodes[index], clicked_point);
                if (distance < distance_tolerance)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            NodePoint node;
            int index;

            index = get_node_index_on_click(e);
            if (node_mode_rb.Checked)
            {
                if (index >= 0) // there is a node there
                {
                    this.graph.queue_terminal(this.graph.nodes[index]);
                }
                else
                {
                    node = new NodePoint(e.X, e.Y, this.graph.nodes.Count);
                    this.graph.nodes.Add(node);
                }
            }
            else
            {
                if (index < 0)
                    return;
                node = this.graph.nodes[index];
                node.toggle();
                this.graph.add_to_selection(node);
                this.graph.process_selection();
            }
            panel1.Invalidate();
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
            this.graph.reset();
            Preset.get_preset(preset_size, panel1.Width, panel1.Height, this.graph);
            Preset.connect_preset(graph);
            panel1.Invalidate();
        }

        private void find_path_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.graph.path = this.graph.find_path();
            }
            catch (Exception exception)
            {
                DisplayUtility.display_message(exception.Message);
            }
            panel1.Invalidate();
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

            DisplayUtility.display_message(message);
        }

        private void preset_size_up_down_ValueChanged(object sender, EventArgs e)
        {
            this.preset_size = (int)preset_size_up_down.Value;
        }
    }
}
