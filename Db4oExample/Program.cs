using Db4objects.Db4o;
using Network.Enums;
using Network.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Db4oExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile("network.data.db4o"))
            {
                StoreExample(db);

                //fetch all Persons from the database
                IObjectSet result = db.QueryByExample(typeof(Node));
                var nodes = new List<Node>();

                //query through the results and print them out
                while (result.HasNext())
                {
                    Node next = (Node)result.Next();
                    nodes.Add(next);
                }

                var source = nodes.FirstOrDefault(n => n.Type == NodeType.Source);
                var consumer = nodes.FirstOrDefault(n => n.Type == NodeType.Consumer);

                var paths = source.FindAllPaths(consumer);

                //Close the database
                db.Close();
            }
        }

        public static void StoreExample(IObjectContainer db)
        {
            Node p = new Node(NodeType.Source, "P");
            Node m = new Node(NodeType.Monitor, "M");
            Node u = new Node(NodeType.Consumer, "U");
            Node a = new Node(NodeType.Intermediate, "A");
            Node b = new Node(NodeType.Intermediate, "B");
            Node c = new Node(NodeType.Intermediate, "C");
            Node d = new Node(NodeType.Intermediate, "D");

            p.Edges.Add(new Edge(p, c));
            c.Edges.Add(new Edge(c, m));
            c.Edges.Add(new Edge(c, a));
            c.Edges.Add(new Edge(c, b));
            a.Edges.Add(new Edge(a, d));
            b.Edges.Add(new Edge(b, d));
            d.Edges.Add(new Edge(d, u));

            db.Store(p);
            db.Store(m);
            db.Store(u);
            db.Store(a);
            db.Store(b);
            db.Store(c);
            db.Store(d);
            db.Commit();
        }
    }
}
