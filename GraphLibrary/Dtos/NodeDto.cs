using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Dtos
{
    public class NodeDto
    {
        public string Id { get; set; }
        public bool IsTerminal { get; set; } = false;
    }
}
