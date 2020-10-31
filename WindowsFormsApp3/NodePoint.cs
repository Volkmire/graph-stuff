using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class NodePoint
    {
        public const int Radius = 10;
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsActivated { get; private set; }
        public int Id { get; private set; }
        public bool IsTerminal { get; private set; }

        public NodePoint DiscoveredBy { get; set; }

        public List<NodePoint> Edges { get; }

        public NodePoint(int x, int y, int id = -1)
        {
            X = x;
            Y = y;
            IsActivated = false;
            IsTerminal = false;
            Edges = new List<NodePoint>();
            DiscoveredBy = null;
            Id = id;
        }
        public static NodePoint AdjustCenter(int x, int y)
        {
            return new NodePoint(x - Radius / 2, y - Radius / 2);
        }

        public void AddEdge(NodePoint node)
        {
            if (!Edges.Contains(node))
            {
                Edges.Add(node);
                node.Edges.Add(this); // the graph is undirected for now;
            }
        }
        
        public int FindEdge(NodePoint edge)
        {
            int n = 0;

            while (n < Edges.Count)
            {
                if (Edges[n] == edge)
                {
                    return n;
                }
                n++;
            }

            return -1;
        }

        public void RemoveEdge(NodePoint node)
        {
            Edges.Remove(node);
            node.Edges.Remove(this);
        }

        public void ToggleActive()
        {
            IsActivated = !IsActivated;
        }

        public void ToggleTerminal()
        {
            IsTerminal = !IsTerminal;
        }
    }

}
