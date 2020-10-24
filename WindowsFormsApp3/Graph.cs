using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Graph
    {
        //public NodePoint start;
        //public NodePoint end;
        public List<NodePoint> nodes;
        public List<NodePoint> current_selection;
        public Queue<NodePoint> terminals;
        private Queue<NodePoint> node_queue;

        public Graph()
        {
            //this.start = null;
            //this.end = null;
            this.nodes = new List<NodePoint>();
            this.node_queue = new Queue<NodePoint>();
            this.current_selection = new List<NodePoint>();
            this.terminals = new Queue<NodePoint>();
        }

        public void add_node(NodePoint node)
        {
            this.nodes.Add(node);
        }

        public void add_to_selection(NodePoint node)
        {
            this.current_selection.Add(node);
        }

        public void queue_terminal(NodePoint node)
        {
            NodePoint extra_node;

            
            if (this.node_queue.Count >= 2)
            {
                extra_node = this.node_queue.Dequeue();
                extra_node.toggle_terminal();
            }
            node.toggle_terminal();
            this.node_queue.Enqueue(node);
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
                }
                this.current_selection[0].toggle();
                this.current_selection[1].toggle();
                this.current_selection.Clear();
            }
        }

        //public void set_start()
        //{
        //    if (this.current_selection.Count == 1)
        //    {
        //        this.start = this.current_selection[0];
        //        this.start.toggle_terminal();
        //        this.start.toggle();
        //    }
        //}

        //public void set_end()
        //{
        //    if (this.current_selection.Count == 1)
        //    {
        //        this.end = this.current_selection[0];
        //        this.end.toggle_terminal();
        //        this.end.toggle();
        //    }
        //}

        public void reset_edges()
        {
            foreach (NodePoint node in this.nodes)
            {
                node.edges.Clear();
            }
        }

        public void clear()
        {
            this.nodes.Clear();
            //this.start = null;
            //this.end = null;
            this.current_selection.Clear();
            this.node_queue.Clear();
        }

    }
}
