using GUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GUI.Views
{
    class CanvasView
    {        
        private readonly CanvasModel _canvas;
        private readonly Graphics _graphics;
        private readonly Color _backColor;
        private readonly Pen _pen = new Pen(Color.Black, 2);
        private readonly Brush _highlightBrush = new SolidBrush(Color.Red);        
        private readonly Pen _solutionPen = new Pen(Color.Green, 2);
        private readonly Brush _solutionBrush = new SolidBrush(Color.Green);


        public CanvasView(Graphics graphics, CanvasModel canvas, Color backColor)
        {
            _graphics = graphics;
            _canvas = canvas;
            _backColor = backColor;
        }

        public void Render()
        {
            _graphics.Clear(_backColor);
            if (_canvas.Nodes != null)
                _canvas.Nodes.ForEach(node => 
                {
                    _graphics.DrawEllipse(_pen, node.X - _canvas.Radius/2, node.Y - _canvas.Radius/2, _canvas.Radius, _canvas.Radius);
                });
            
            if (_canvas.Edges != null)
                _canvas.Edges.ForEach(edge =>
                {
                    _graphics.DrawLine(_pen, edge.Ends.Item1.X, edge.Ends.Item1.Y, edge.Ends.Item2.X, edge.Ends.Item2.Y);
                });

            if (_canvas.Solution != null)
                _canvas.Solution.ForEach(edge =>
                {
                    _graphics.DrawLine(_solutionPen, edge.Ends.Item1.X, edge.Ends.Item1.Y, edge.Ends.Item2.X, edge.Ends.Item2.Y);
                });

            if (_canvas.ActiveNode != null)
                _graphics.FillEllipse(
                    _highlightBrush, 
                    _canvas.ActiveNode.X - _canvas.Radius / 2, 
                    _canvas.ActiveNode.Y - _canvas.Radius / 2, 
                    _canvas.Radius, 
                    _canvas.Radius
                );

            if (_canvas.Terminals != null)
                _canvas.Terminals.ForEach(terminal =>
                {
                    _graphics.FillEllipse(
                        _solutionBrush,
                        terminal.X - _canvas.Radius / 2,
                        terminal.Y - _canvas.Radius / 2,
                        _canvas.Radius,
                        _canvas.Radius
                    );
                });
            

        }
    }
}
