using Network.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.AlgoStructures
{
    public class QueueItem
    {

        public Node Node { get; private set; }
        public List<Edge> Visited { get; private set; }

        public QueueItem(Node node, List<Edge> visited)
        {
            Node = node;
            Visited = visited;
        }

    }
}
