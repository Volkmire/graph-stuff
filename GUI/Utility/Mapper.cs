using GraphLibrary.Dtos;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Utility
{
    class Mapper
    {
        public static EdgeDto ToEdgeDto(EdgeModel edge) => new EdgeDto()
        {
            Ends = new Tuple<string, string>(edge.Ends.Item1.Id, edge.Ends.Item2.Id)
        };

        public static NodeDto ToNodeDto(NodeModel node) => new NodeDto()
        {
            Id = node.Id.ToString()
        };

        public static GraphDto ToGraphDto(CanvasModel canvas)
        {
            var graphDto = new GraphDto()
            {
                Nodes = new List<NodeDto>(canvas.Nodes.ConvertAll(ToNodeDto)),
                Edges = new List<EdgeDto>(canvas.Edges.ConvertAll(ToEdgeDto))
            };

            foreach (var terminal in canvas.Terminals)
            {
                graphDto.Nodes.Find(node => node.Id == terminal.Id).IsTerminal = true;
            }

            return graphDto;
        }
    }
}
