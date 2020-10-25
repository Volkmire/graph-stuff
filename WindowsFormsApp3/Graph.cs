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
        public List<NodePoint> nodes;
        public List<NodePoint> current_selection;
        public List<NodePoint> terminals;
        public List<NodePoint> path;
        private Queue<NodePoint> node_queue;

        public Graph()
        {
            this.nodes = new List<NodePoint>();
            this.node_queue = new Queue<NodePoint>();
            this.current_selection = new List<NodePoint>();
            this.terminals = new List<NodePoint>();
            this.path = new List<NodePoint>();
        }

        public void reset()
        {
            this.nodes.Clear();
            this.current_selection.Clear();
            this.terminals.Clear();
            this.node_queue.Clear();
            this.path.Clear();
        }

        public void add_to_selection(NodePoint node)
        {
            this.current_selection.Add(node);
        }

        public void queue_terminal(NodePoint node)
        {
            int index;

            index = this.terminals.IndexOf(node);
            if (index >= 0)
            {
                this.terminals[index].toggle_terminal();
                this.terminals.RemoveAt(index);
            }
            else if (this.terminals.Count == 2)
            {
                this.terminals[0].toggle_terminal();
                this.terminals.RemoveAt(0);
                node.toggle_terminal();
                this.terminals.Add(node);
            }
            else
            {
                node.toggle_terminal();
                this.terminals.Add(node);
            }
        }

        public void process_selection()
        {
            int edge_index;

            if (this.current_selection.Count == 2)
            {
                edge_index = this.current_selection[0].find_edge(this.current_selection[1]);
                if (edge_index == -1)
                {
                    this.current_selection[0].add_edge(this.current_selection[1]);
                }
                else
                {
                    this.current_selection[0].remove_edge(this.current_selection[1]);
                    this.path.Clear();
                }
                this.current_selection[0].toggle();
                this.current_selection[1].toggle();
                this.current_selection.Clear();
            }
        }

        private void discover_edges(NodePoint node) //deprecated
        {
            foreach (NodePoint _node in node.edges)
            {
                if (_node.discovered_via == null)
                    _node.discovered_via = node;
            }
        }

        private void enqueue_and_discover(NodePoint node)
        {
            foreach (NodePoint _node in node.edges)
            {
                if (_node.discovered_via == null)
                {
                    this.node_queue.Enqueue(_node);
                    _node.discovered_via = node;
                }
            }
        }

        public List<NodePoint> backtrack(NodePoint terminal)
        {
            NodePoint current_node;

            current_node = terminal;
            while (current_node != this.terminals[0])
            {
                this.path.Add(current_node);
                current_node = current_node.discovered_via;
            }
            this.path.Add(current_node);

            return this.path;
        }

        public List<NodePoint> find_path()
        {
            NodePoint current_node;

            reset_discovered();
            this.node_queue.Clear();
            this.path.Clear();
            if (this.terminals.Count != 2)
            {
                throw new Exception("Select two points to find a path!");
            }
            enqueue_and_discover(this.terminals[0]);
            while (this.node_queue.Count != 0)
            {
                current_node = this.node_queue.Dequeue();
                if (current_node == this.terminals[1])
                {
                    return backtrack(current_node);
                }
                if (current_node == this.terminals[0])
                    continue;
                enqueue_and_discover(current_node);
            }
            throw new Exception("There is no path");
        }

        public void reset_edges()
        {
            foreach (NodePoint node in this.nodes)
            {
                node.edges.Clear();
            }
        }

        public void reset_discovered()
        {
            foreach (NodePoint node in this.nodes)
            {
                node.discovered_via = null;
            }
        }
    }
}
