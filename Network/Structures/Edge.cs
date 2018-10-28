using Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Structures
{
    public class Edge
    {
        public Node Node1 { get; private set; }

        public Node Node2 { get; private set; }

        public EdgeStatus Status { get; set; }

        public Edge(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
            Status = EdgeStatus.Connected;
        }

        public override string ToString()
        {
            return $"Node1: {Node1.Name},  Node2: {Node2.Name}, Status : {Status}";
        }
    }
}
