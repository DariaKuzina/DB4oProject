using Network.AlgoStructures;
using Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Structures
{
    public class Node 
    {
        public NodeType Type { get; set; }

        public NodeStatus Status { get; set; }

        public string Name { get; set; }

        public List<Edge> Edges { get; set; }

        public Node(NodeType type, string name)
        {
            Type = type;
            Name = name;
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Найти все пути до конечного узла из текущего
        /// </summary>
        /// <param name="endNode">Конечный узел</param>
        /// <returns>Перечисление списков ребер, в котором каждый список формирует путь</returns>
        public IEnumerable<List<Edge>> FindAllPaths(Node endNode)
        {
            var queue = new Queue<QueueItem>();
            queue.Enqueue(new QueueItem(this, new List<Edge>()));
            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();
                foreach (var edge in currentItem.Node.Edges)
                {
                    if (!currentItem.Visited.Contains(edge))
                    {
                        List<Edge> visited = new List<Edge>(currentItem.Visited);
                        visited.Add(edge);
                        if (edge.Node2 == endNode)
                        {
                            yield return visited;
                        }
                        else
                        {
                            queue.Enqueue(new QueueItem(edge.Node2, visited));
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name},  Type: {Type}, Status : {Status}";
        }
    }
}
