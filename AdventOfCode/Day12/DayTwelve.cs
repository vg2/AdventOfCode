using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day12
{
    internal class DayTwelve
    {
        private const string START = "start";
        private const string END = "end";
        private readonly List<Node> nodes;

        public DayTwelve(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var pairs = lines.Select(pair => new { A = pair.Split('-').First(), B = pair.Split('-').Last() });
            var nodes = new List<Node>();

            foreach (var pair in pairs)
            {
                Node A;
                if (nodes.All(n => n.Label != pair.A))
                {
                    A = new Node(pair.A, pair.A == START, pair.A == END);
                    nodes.Add(A);
                }
                else
                {
                    A = nodes.Single(n => n.Label == pair.A);
                }

                Node B;
                if (nodes.All(n => n.Label != pair.B))
                {
                    B = new Node(pair.B, pair.B == START, pair.B == END);
                    nodes.Add(B);
                }
                else
                {
                    B = nodes.Single(n => n.Label == pair.B);
                }

                if (!A.Linked.Contains(B))
                {
                    A.Linked.Add(B);
                }

                if (!B.Linked.Contains(A))
                {
                    B.Linked.Add(A);
                }
            }

            this.nodes = nodes;
        }

        public long Answer()
        {
            var paths = new List<List<Node>>();
            var start = this.nodes.Single(n => n.IsStart);

            paths.AddRange(Traverse(start, new List<Node>() { }));

            return paths.Count(p => p.Last().IsEnd);
        }

        public List<List<Node>> Traverse(Node startNode, List<Node> currentPath)
        {
            currentPath.Add(startNode);

            if (startNode.IsEnd)
            {
                return new List<List<Node>> { currentPath };
            }

            var paths = new List<List<Node>>();

            foreach (var node in startNode.Linked)
            {
                if (currentPath.Count(n => n == node) < node.MaxVisits)
                {
                    var copyPath = Node.CopyPath(currentPath);
                    paths.AddRange(Traverse(node, copyPath));
                }
            }
            paths.Add(currentPath);

            return paths;
        }
    }

    internal class Node
    {
        public string Label { get; }
        public bool IsStart { get; }
        public bool IsEnd { get; }
        public int MaxVisits { get; }

        public Node(string label, bool isStart = false, bool isEnd = false)
        {
            Label = label;
            MaxVisits = label.ToUpper() == label ? int.MaxValue : 1;
            IsStart = isStart;
            IsEnd = isEnd;
            Linked = new List<Node>();
        }

        public List<Node> Linked { get; set; }

        public static List<Node> CopyPath(List<Node> path)
        {
            var newPath = new List<Node>();
            path.ForEach(n => newPath.Add(n));
            return newPath;
        }
    }
}
