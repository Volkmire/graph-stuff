using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class GraphModel
    {
        public List<NodeModel> Nodes { get; set; }
        public List<NodeModel> Solution { get; set; }
    }
}
