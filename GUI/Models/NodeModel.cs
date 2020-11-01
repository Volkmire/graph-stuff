using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    class NodeModel
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public NodeModel(int x, int y)
        {
            X = x;
            Y = y;
            Id = Guid.NewGuid().ToString();
        }
    }
}
