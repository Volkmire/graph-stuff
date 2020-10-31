using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Dtos
{
    class GraphDto
    {
        public List<NodeDto> Nodes { get; set; }
        public List<EdgeDto> Edges { get; set; }
    }
}
