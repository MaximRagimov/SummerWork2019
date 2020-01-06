using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AlgoOnGraphs
{
    class Graph
    {
        public ObservableCollection<Node> Nodes { get; } = new ObservableCollection<Node>();
        public ObservableCollection<Edge> Edges { get; } = new ObservableCollection<Edge>();

        internal void Clear()
        {
            Nodes.Clear();
            Edges.Clear();
        }

        internal void AddEdge(int row, int col)
        {
            if (row != col)
                Edges.Add(new Edge { A = Nodes[row], B = Nodes[col] });
        }

        internal void RemoveEdge(int row, int col)
        {
            var a = Nodes[row];
            var b = Nodes[col];
            var edge = Edges.Where(x => x.A == a && x.B == b || x.A == b && x.B == a).FirstOrDefault();
            if (edge != null)
                Edges.Remove(edge);
        }
    }
    class Node
    {
        public string Text { get; set; } // полезные данные, характеризующие узел
        public Point Pos { get; set; } // позиция узла на Canvas, нужна только для View
    }
    class Edge
    {
        public Node A { get; set; } // ребро соединяет узел A
        public Node B { get; set; } // c узлом B
        public SolidColorBrush Stroke { get; internal set; }
    }
    class MyMatrix
    {
        int[,] mtx;

        public int N => mtx.GetLength(0);
        public int this[int row, int col]
        {
            get => mtx[row, col];
            set => mtx[row, col] = value;
        }
        public MyMatrix(int rows, int cols)
        {
            mtx = new int[rows, cols];
        }
        public static MyMatrix operator + (MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix resultMatrix = new MyMatrix(matrix1.mtx.GetLength(0), matrix1.mtx.GetLength(0));
            int sumTemp = 0;

            for (int i = 0; i < matrix1.mtx.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.mtx.GetLength(0); j++)
                {
                    sumTemp = matrix1.mtx[i, j] + matrix2.mtx[i, j];

                    if (sumTemp != 0)
                        resultMatrix.mtx[i, j] = 1;
                    else
                        resultMatrix.mtx[i, j] = 0;
                }
            }

            return resultMatrix;
        }

        public static MyMatrix operator * (MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix resultMatrix = new MyMatrix (matrix1.mtx.GetLength(0), matrix1.mtx.GetLength(0));
            int sumTemp = 0;

            for (int i = 0; i < matrix1.mtx.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.mtx.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix1.mtx.GetLength(0); k++)
                    {
                        sumTemp += matrix1.mtx[i, k] * matrix2.mtx[k, j];
                    }

                    if (sumTemp != 0)
                        resultMatrix.mtx[i, j] = 1;
                    else
                        resultMatrix.mtx[i, j] = 0;
                }
            }

            return resultMatrix;
        }
    }
}
