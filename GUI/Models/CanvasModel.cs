using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class CanvasModel
    {
        public List<NodeModel> Nodes { get; set; } = new List<NodeModel>();
        public List<EdgeModel> Edges { get; set; } = new List<EdgeModel>();
        public List<EdgeModel> Solution { get; set; } = new List<EdgeModel>();
        public List<NodeModel> Terminals { get; set; } = new List<NodeModel>(2);
        public NodeModel ActiveNode { get; set; }
        public int Radius { get; }
        
        public CanvasModel(int radius)
        {
            Radius = Math.Abs(radius);
        }

    }
}
