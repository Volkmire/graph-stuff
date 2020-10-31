using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class Graph
    {
        public List<NodePoint> Nodes;
        public List<NodePoint> CurrentSelection;
        public List<NodePoint> Terminals;
        public List<NodePoint> Path;
        private Queue<NodePoint> NodeQueue;

        public Graph()
        {
            Nodes = new List<NodePoint>();
            NodeQueue = new Queue<NodePoint>();
            CurrentSelection = new List<NodePoint>();
            Terminals = new List<NodePoint>();
            Path = new List<NodePoint>();
        }

        public void Reset()
        {
            Nodes.Clear();
            CurrentSelection.Clear();
            Terminals.Clear();
            NodeQueue.Clear();
            Path.Clear();
        }

        public void AddToSelection(NodePoint node)
        {
            CurrentSelection.Add(node);
        }

        public void QueueTerminal(NodePoint node)
        {
            int index;

            index = Terminals.IndexOf(node);
            if (index >= 0)
            {
                Terminals[index].ToggleTerminal();
                Terminals.RemoveAt(index);
            }
            else if (this.Terminals.Count == 2)
            {
                Terminals[0].ToggleTerminal();
                Terminals.RemoveAt(0);
                node.ToggleTerminal();
                Terminals.Add(node);
            }
            else
            {
                node.ToggleTerminal();
                this.Terminals.Add(node);
            }
        }

        public void ProcessSelection()
        {
            if (CurrentSelection.Count == 2)
            {
                int edge_index = CurrentSelection[0].FindEdge(CurrentSelection[1]);
                if (edge_index == -1)
                {
                    CurrentSelection[0].AddEdge(CurrentSelection[1]);
                }
                else
                {
                    CurrentSelection[0].RemoveEdge(CurrentSelection[1]);
                    Path.Clear();
                }
                CurrentSelection[0].ToggleActive();
                CurrentSelection[1].ToggleActive();
                CurrentSelection.Clear();
            }
        }

        private void EnqueueAndDiscover(NodePoint node)
        {
            foreach (NodePoint _node in node.Edges)
            {
                if (_node.DiscoveredBy == null)
                {
                    this.NodeQueue.Enqueue(_node);
                    _node.DiscoveredBy = node;
                }
            }
        }

        public List<NodePoint> Backtrack(NodePoint terminal)
        {
            NodePoint currentNode = terminal;
            while (currentNode != Terminals[0])
            {
                Path.Add(currentNode);
                currentNode = currentNode.DiscoveredBy;
            }
            Path.Add(currentNode);

            return Path;
        }

        public List<NodePoint> FindPath()
        {
            if (Terminals.Count != 2)
            {
                throw new Exception("Select two points to find a Path!");
            }

            NodePoint currentNode;

            ResetDiscovered();
            NodeQueue.Clear();
            Path.Clear();            

            EnqueueAndDiscover(Terminals[0]);

            while (NodeQueue.Count != 0)
            {
                currentNode = NodeQueue.Dequeue();
                if (currentNode == Terminals[1])
                {
                    return Backtrack(currentNode);
                }
                if (currentNode == Terminals[0])
                    continue;
                EnqueueAndDiscover(currentNode);
            }

            throw new Exception("There is no Path");
        }

        public void ResetEdges()
        {
            foreach (NodePoint node in Nodes)
            {
                node.Edges.Clear();
            }
        }

        public void ResetDiscovered()
        {
            foreach (NodePoint node in Nodes)
            {
                node.DiscoveredBy = null;
            }
        }
    }
}
