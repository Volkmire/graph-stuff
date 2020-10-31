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
        private int PresetSize;
        private int Tolerance;
        public Graph Graph;
        private Pen DefaultPen;
        private Pen PathPen;

        public Form1()
        {
            InitializeComponent();
            node_mode_rb.Checked = true;
            Graph = new Graph();
            DefaultPen = new Pen(Color.LightSkyBlue, 2);
            PathPen = new Pen(Color.DarkRed, 3);
            Tolerance = 10;
            PresetSize = (int)preset_size_up_down.Value;
        }

        private void RedrawNodes(PaintEventArgs e)
        {
            Graphics Graphics;

            Graphics = e.Graphics;
            DisplayUtility.DrawGraph(Graphics, this.DefaultPen, this.PathPen, this.Graph);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (Graph.Nodes.Count > 0)
            {
                RedrawNodes(e);
            }
        }

        private int get_node_index_on_click(MouseEventArgs e)
        {
            NodePoint clicked_Point;
            double distance;
            int index;

            index = 0;
            clicked_Point = new NodePoint(e.X, e.Y);
            while (index < Graph.Nodes.Count)
            {
                distance = MathUtility.GetDistance(this.Graph.Nodes[index], clicked_Point);
                if (distance < Tolerance)
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
            int index = get_node_index_on_click(e);

            if (node_mode_rb.Checked)
            {
                if (index >= 0) // there is a node there
                {
                    Graph.QueueTerminal(Graph.Nodes[index]);
                }
                else
                {
                    node = new NodePoint(e.X, e.Y, Graph.Nodes.Count);
                    Graph.Nodes.Add(node);
                }
            }
            else
            {
                if (index < 0)
                    return;

                node = Graph.Nodes[index];
                node.ToggleActive();

                Graph.AddToSelection(node);
                Graph.ProcessSelection();
            }

            panel1.Invalidate();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            Graph.Reset();
            panel1.Invalidate();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            Graph.ResetEdges();
            Graph.ResetDiscovered();
            Graph.Path.Clear();
            panel1.Invalidate();
        }

        private void preset_button_Click(object sender, EventArgs e)
        {
            Graph.Reset();
            Preset.GetPreset(PresetSize, panel1.Width, panel1.Height, this.Graph);
            Preset.ConnectPreset(Graph);
            panel1.Invalidate();
        }

        private void find_path_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Graph.Path = this.Graph.FindPath();
            }
            catch (Exception exception)
            {
                DisplayUtility.DisplayMessage(exception.Message);
            }
            panel1.Invalidate();
        }

        private void help_button_Click(object sender, EventArgs e)
        {
            string message;

            message = "This is a toy Pathfinding program.\n" +
            "To add a node, click the panel in NODE MODE;\n" +
            "To add an edge, click two Nodes in EDGE MODE;\n" +
            "To remove an edge, click two Nodes that have a common edge;\n" +
            "To find a Path, select two Nodes in NODE MODE and click FIND PATH;\n" +
            "To use a premade Graph, click USE PRESET.";

            DisplayUtility.DisplayMessage(message);
        }

        private void preset_size_up_down_ValueChanged(object sender, EventArgs e)
        {
            PresetSize = (int)preset_size_up_down.Value;
        }
    }
}
