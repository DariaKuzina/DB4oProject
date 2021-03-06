﻿using Network.AlgoStructures;
using Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Structures
{
    public class Node : IEquatable<Node>
    {
        public NodeType Type { get; set; }

        public NodeStatus Status { get; set; }

        public NodeColor Color { get; set; }

        public string Name { get; set; }

        public List<Edge> Edges { get; set; }

        public Node(NodeType type, string name)
        {
            Status = NodeStatus.Undefined;
            Color = NodeColor.Green;
            Type = type;
            Name = name;
            Edges = new List<Edge>();
            IsAvailable = true;
        }

        /// <summary>
        /// Actual status of the node (dummy implementation)
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Найти все пути до конечного узла из текущего
        /// </summary>
        /// <param name="endNode">Конечный узел</param>
        /// <param name="countConnetedOnly">Учитывать только активные узлы</param>
        /// <returns>Перечисление списков ребер, в котором каждый список формирует путь</returns>
        public List<List<Edge>> FindAllPaths(Node endNode, bool countConnetedOnly)
        {
            var result = new List<List<Edge>>();

            var queue = new Queue<QueueItem>();
            if (!countConnetedOnly || Status == NodeStatus.Connected)
                queue.Enqueue(new QueueItem(this, new List<Edge>()));

            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();

                if (countConnetedOnly && currentItem.Node.Status != NodeStatus.Connected)
                    continue;

                foreach (var edge in currentItem.Node.Edges)
                {
                    if (!currentItem.Visited.Contains(edge))
                    {
                        List<Edge> visited = new List<Edge>(currentItem.Visited);
                        visited.Add(edge);
                        if (edge.Node2.Name == endNode.Name)
                        {
                            result.Add(visited);
                        }
                        else if (!countConnetedOnly || edge.Node2.Status == NodeStatus.Connected)
                        {
                            queue.Enqueue(new QueueItem(edge.Node2, visited));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Проверить доступность узлов с точки зрения мониторинговой системы
        /// </summary>
        public void CheckAssesibility()
        {
            if (Type != NodeType.Monitor)
                throw new ArgumentException("Only monitoring system can check status");

            Status = NodeStatus.Connected;
            var visited = new HashSet<string>();

            //create queue for BFS
            var queue = new Queue<Node>();
            visited.Add(Name);
            queue.Enqueue(this);

            //loop through all nodes in queue
            while (queue.Count != 0)
            {
                //Deque a vertex from queue and print it.
                var s = queue.Dequeue();

                //Get all adjacent vertices of s
                foreach (var node in s.Edges.Select(e => e.Node2))
                {
                    if (!visited.Contains(node.Name))
                    {
                        visited.Add(node.Name);

                        //if node is not available we can't go further
                        if (node.IsAvailable)
                        {
                            node.Status = NodeStatus.Connected;
                            queue.Enqueue(node);
                        }
                        else
                        {
                            node.Status = NodeStatus.Disconnected;
                        }
                    }
                }

            }

        }

        public override string ToString()
        {
            return $"Name: {Name},  Type: {Type}, Status: {Status}, Color : {Color}";
        }

        public bool Equals(Node other)
        {
            return other != null && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
