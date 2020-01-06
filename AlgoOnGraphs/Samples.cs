using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlgoOnGraphs
{
    static class Samples
    {
        public static Graph Nodes3()
        {
            var graph = new Graph();

            var node1 = new Node { Pos = new Point(20, 100), Text = "1" };
            var node2 = new Node { Pos = new Point(220, 100), Text = "2" };
            var node3 = new Node { Pos = new Point(120, 200), Text = "3" };
            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);
            var edge1 = new Edge { A = node1, B = node2 };
            var edge2 = new Edge { A = node2, B = node3 };
            graph.Edges.Add(edge1);
            graph.Edges.Add(edge2);

            return graph;
        }

        public static Graph Nodes5()
        {
            var graph = new Graph();

            var node11 = new Node { Pos = new Point(20, 100), Text = "1" };
            var node12 = new Node { Pos = new Point(220, 100), Text = "2" };
            var node13 = new Node { Pos = new Point(20, 300), Text = "3" };
            var node14 = new Node { Pos = new Point(220, 300), Text = "4" };
            var node15 = new Node { Pos = new Point(70, 200), Text = "5" };
            graph.Nodes.Add(node11);
            graph.Nodes.Add(node12);
            graph.Nodes.Add(node13);
            graph.Nodes.Add(node14);
            graph.Nodes.Add(node15);
            var edge11 = new Edge { A = node11, B = node12 };
            var edge12 = new Edge { A = node11, B = node13 };
            var edge13 = new Edge { A = node14, B = node15 };
            var edge14 = new Edge { A = node11, B = node14 };
            graph.Edges.Add(edge11);
            graph.Edges.Add(edge12);
            graph.Edges.Add(edge13);
            graph.Edges.Add(edge14);

            return graph;
        }

        public static Graph Nodes7()
        {
            var graph = new Graph();

            var node21 = new Node { Pos = new Point(100, 100), Text = "1" };
            var node22 = new Node { Pos = new Point(300, 100), Text = "2" };
            var node23 = new Node { Pos = new Point(50, 200), Text = "3" };
            var node24 = new Node { Pos = new Point(130, 200), Text = "4" };
            var node25 = new Node { Pos = new Point(350, 200), Text = "5" };
            var node26 = new Node { Pos = new Point(100, 300), Text = "6" };
            var node27 = new Node { Pos = new Point(300, 300), Text = "7" };
            graph.Nodes.Add(node21);
            graph.Nodes.Add(node22);
            graph.Nodes.Add(node23);
            graph.Nodes.Add(node24);
            graph.Nodes.Add(node25);
            graph.Nodes.Add(node26);
            graph.Nodes.Add(node27);
            var edge21 = new Edge { A = node21, B = node22 };
            var edge22 = new Edge { A = node21, B = node23 };
            var edge23 = new Edge { A = node24, B = node25 };
            var edge24 = new Edge { A = node26, B = node27 };
            var edge25 = new Edge { A = node21, B = node25 };
            var edge26 = new Edge { A = node21, B = node26 };
            graph.Edges.Add(edge21);
            graph.Edges.Add(edge22);
            graph.Edges.Add(edge23);
            graph.Edges.Add(edge24);
            graph.Edges.Add(edge25);
            graph.Edges.Add(edge26);

            return graph;
        }
    }
}
