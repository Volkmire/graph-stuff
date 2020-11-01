using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class NodeModel
    {
        public string Id { get; set; }
        public List<NodeModel> Edges { get; set; }
        public bool IsTerminal { get; set; }
    }
}
