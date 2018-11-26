using Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Structures
{
    public class Edge : IEquatable<Edge>
    {
        public Node Node1 { get; private set; }

        public Node Node2 { get; private set; }

        public Edge(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public override string ToString()
        {
            return $"Node1: {Node1.Name},  Node2: {Node2.Name}";
        }

        public bool Equals(Edge other)
        {
            return other != null && (Node1 == other.Node1 && Node2 == other.Node2 ||
                Node2 == other.Node1 && Node1 == other.Node2);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge);
        }
        public override int GetHashCode()
        {
            return Node1.Name.GetHashCode() + Node2.Name.GetHashCode();
        }
    }
}
