using GUI.Controllers;
using GUI.Models;
using GUI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GraphGUI : Form
    {
        private CanvasController _canvasController;
        private CanvasView _canvasView;

        public GraphGUI()
        {
            InitializeComponent();
        }

        private void GraphGUI_Load(object sender, EventArgs e)
        {
            var canvas = new CanvasModel(10);
            _canvasController = new CanvasController(canvas);
            _canvasView = new CanvasView(drawPanel.CreateGraphics(), canvas, drawPanel.BackColor);
            _canvasView.Render();
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawRadioButton.Checked)
                _canvasController.Add(e.X, e.Y);
            if (selectRadioButton.Checked)
                _canvasController.SelectTerminal(e.X, e.Y);

            _canvasView.Render();
        }

        private void ResetEdgesButton_Click(object sender, EventArgs e)
        {
            _canvasController.ResetEdges();
            _canvasView.Render();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _canvasController.Clear();
            _canvasView.Render();
        }

        private void DrawRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectRadioButton.Checked = !drawRadioButton.Checked;
        }

        private void FindPathButton_Click(object sender, EventArgs e)
        {
            _canvasController.FindPathAsync();
            _canvasView.Render();
        }
    }
}
