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

                ColorClientAvailable(db);
            }
        }

        public static void ColorClientAvailable(IObjectContainer db)
        {
            IObjectSet result = db.QueryByExample(typeof(Node));
            var nodes = new List<Node>();

            //query through the results and print them out
            while (result.HasNext())
            {
                Node next = (Node)result.Next();
                next.Status = NodeStatus.Undefined;
                nodes.Add(next);
            }

            var source = nodes.FirstOrDefault(n => n.Type == NodeType.Source);
            var consumer = nodes.FirstOrDefault(n => n.Type == NodeType.Consumer);
            var monitor = nodes.FirstOrDefault(n => n.Type == NodeType.Monitor);

            //Строим топологию
            var paths = source.FindAllPaths(consumer, false);

            //Проверяем доступность узлов из мониторинговой системы
            monitor.CheckAssesibility();

            //Ищем только доступные пути
            var pathsAvailable = source.FindAllPaths(consumer, true);

            var vertexes = paths.SelectMany(p => p.Select(n => n.Node1))
                .Union(paths.SelectMany(p => p.Select(n => n.Node2)))
                .Distinct();

            if (pathsAvailable.Count == 0)
                consumer.Color = NodeColor.Red;
            else if (pathsAvailable.Count < paths.Count)
                consumer.Color = NodeColor.Yellow;
            else
                consumer.Color = NodeColor.Green;

            foreach (var v in vertexes)
            {
                Console.WriteLine(v);

            }

            //Close the database
            db.Close();
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

            //Устанавливаем "настоящий" статус узла
            b.IsAvailable = false;
            a.IsAvailable = false;

            p.Edges.Add(new Edge(p, c));
            c.Edges.Add(new Edge(c, p));

            c.Edges.Add(new Edge(c, m));
            m.Edges.Add(new Edge(m, c));

            c.Edges.Add(new Edge(c, a));
            a.Edges.Add(new Edge(a, c));

            c.Edges.Add(new Edge(c, b));
            b.Edges.Add(new Edge(b, c));

            a.Edges.Add(new Edge(a, d));
            d.Edges.Add(new Edge(d, a));

            b.Edges.Add(new Edge(b, d));
            d.Edges.Add(new Edge(d, b));

            d.Edges.Add(new Edge(d, u));
            u.Edges.Add(new Edge(u, d));

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
