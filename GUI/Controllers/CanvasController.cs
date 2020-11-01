using GUI.Connector;
using GUI.Models;
using GUI.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GraphLibrary.Dtos;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controllers
{
    class CanvasController
    {
        private readonly CanvasModel _canvas;

        public CanvasController(CanvasModel canvas)
        {
            _canvas = canvas;
        }

        public void Add(int x, int y)
        {
            var adjacentNode = GetNode(x, y);

            if (adjacentNode == null)
            {
                // если не попали мышкой на ноду, создаем новую
                _canvas.Nodes.Add(new NodeModel(x, y));
                return;
            }

            if (_canvas.ActiveNode == adjacentNode)
            {
                // если попали мышкой в активированную ноду, то деактивируем ее
                _canvas.ActiveNode = null;
                return;
            }

            if (_canvas.ActiveNode == null)
            {
                // если активированных нод нет, то активируем
                _canvas.ActiveNode = adjacentNode;
                return;
            }

            if (_canvas.ActiveNode != adjacentNode)
            {
                // Если грань еще не существует (в любую сторону), то создаем ее 
                if (_canvas.Edges.Find(edge => edge.Ends.Item1 == _canvas.ActiveNode && edge.Ends.Item2 == adjacentNode) == null)
                    if (_canvas.Edges.Find(edge => edge.Ends.Item1 == adjacentNode && edge.Ends.Item2 == _canvas.ActiveNode) == null)
                        _canvas.Edges.Add(new EdgeModel(_canvas.ActiveNode, adjacentNode));
                _canvas.ActiveNode = null;
            }
        }

        public void SelectTerminal(int x, int y)
        {
            var node = GetNode(x, y);

            if (node == null)
                return;

            if (_canvas.Terminals.Contains(node))
            {
                _canvas.Terminals.Remove(node);
                return;
            }

            if (_canvas.Terminals.Count.Equals(2))
                _canvas.Terminals.Remove(_canvas.Terminals[0]);

            _canvas.Terminals.Add(node);
        }

        internal async Task FindPathAsync()
        {
            try
            {
                var solution = await GraphApiConnector.PostGraphAsync(Mapper.ToGraphDto(_canvas));
                UpdateSolution(solution);
            }
            catch (NullReferenceException)
            {
                throw new Exception("No solution!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void ResetEdges()
        {
            _canvas.Edges.Clear();
            _canvas.Solution.Clear();
        }

        internal void Clear()
        {
            _canvas.Nodes.Clear();
            _canvas.Edges.Clear();
            _canvas.Solution.Clear();
            _canvas.Terminals.Clear();
            _canvas.ActiveNode = null;
        }

        private void UpdateSolution(List<EdgeDto> solution)
        {
            if (solution != null)
                solution.ForEach(edge =>
                    _canvas.Solution.Add(
                        new EdgeModel(
                            _canvas.Nodes.Find(node => node.Id == edge.End1),
                            _canvas.Nodes.Find(node => node.Id == edge.End2)
                            )
                        )
                    );
        }

        [return: MaybeNull]
        private NodeModel GetNode(int x, int y) =>
            _canvas.Nodes.Find(
                node =>
                {
                    return (Math.Abs(node.X - x) < _canvas.Radius
                            && Math.Abs(node.Y - y) < _canvas.Radius);
                }
            );
    }
}
