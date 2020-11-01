using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Dtos
{
    public class GraphDto
    {
        public List<NodeDto> Nodes { get; set; }
        public List<EdgeDto> Edges { get; set; }
    }
}
