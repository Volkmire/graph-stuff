using GraphApi.Models;
using GraphLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Utility
{
    class Mapper
    {
        public static GraphModel ToGraphModel(GraphDto graphDto)
        {
            var graph = new GraphModel
            {
                Nodes = graphDto.Nodes.ConvertAll(ToNodeModel)
            };

            foreach (var edge in graphDto.Edges)
            {
                var edge1 = graph.Nodes.Find(node => node.Id == edge.Ends.Item1);
                var edge2 = graph.Nodes.Find(node => node.Id == edge.Ends.Item2);

                edge1.Edges.Add(edge2);
                edge2.Edges.Add(edge1);
            }

            return graph;
        }

        public static NodeModel ToNodeModel(NodeDto nodeDto)
        {
            return new NodeModel()
            {
                Id = nodeDto.Id,
                IsTerminal = nodeDto.IsTerminal
            };
        }

        public static List<EdgeDto> ToEdgeDtos(List<NodeModel> nodes)
        {
            var nodeDtos = new List<EdgeDto>();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodeDtos.Add(new EdgeDto()
                {
                    Ends = new Tuple<string, string>(nodes[i].Id, nodes[i + 1].Id)
                });
            }

            return nodeDtos;
        }
    }
}
