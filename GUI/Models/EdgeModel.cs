using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class EdgeModel
    {
        public Tuple<NodeModel, NodeModel> Ends { get; }
        public bool IsDirectional { get; } = false;

        public EdgeModel(NodeModel a, NodeModel b)
        {
            Ends = new Tuple<NodeModel, NodeModel>(a, b);
        }

        public EdgeModel(NodeModel a, NodeModel b, bool isDirectional)
        {
            Ends = new Tuple<NodeModel, NodeModel>(a, b);
            IsDirectional = isDirectional;
        }
    }
}
