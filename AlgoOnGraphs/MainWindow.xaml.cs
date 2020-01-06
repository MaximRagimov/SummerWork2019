using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace AlgoOnGraphs
{
    public partial class MainWindow : Window
    {
        List<List<Cell>> lsts;
        Graph graph = new Graph();
        Graph graph2 = new Graph();
        int selector = 1;
        private void Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selector = Options.SelectedIndex + 1;
            Problem();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        void Problem()
        {
            graph.Nodes.Clear();
            graph.Edges.Clear();

            switch (selector)
            {
                case 1:
                    graph = Samples.Nodes3();
                    CanvLeft.DataContext = graph;
                    //Алгоритм построения транзитивного замыкания через матрицу
                    TransitiveClosure();
                    Canv.DataContext = graph2;
                    break;
                case 2:
                    graph = Samples.Nodes5();
                    CanvLeft.DataContext = graph;
                    //Алгоритм построения транзитивного замыкания через матрицу
                    TransitiveClosure();
                    Canv.DataContext = graph2;
                    break;
                case 3:
                    graph = Samples.Nodes7();
                    CanvLeft.DataContext = graph;
                    //Алгоритм построения транзитивного замыкания через матрицу
                    TransitiveClosure();
                    Canv.DataContext = graph2;
                    break;
            }
        }

        public void TransitiveClosure()
        {
            //Матрица смежности
            MyMatrix incidenceMatrix = new MyMatrix(graph.Nodes.Count, graph.Nodes.Count);

            for (int i = 0; i < graph.Edges.Count; i++)
            {
                int row = graph.Nodes.IndexOf(graph.Edges[i].A);
                int column = graph.Nodes.IndexOf(graph.Edges[i].B);
                incidenceMatrix[row, column] = 1;
                incidenceMatrix[column, row] = 1;
            }

            lsts = new List<List<Cell>>();

            for (int i = 0; i < incidenceMatrix.N; i++)
            {
                lsts.Add(new List<Cell>());

                for (int j = 0; j < incidenceMatrix.N; j++)
                {
                    lsts[i].Add(new Cell { Value = incidenceMatrix[i, j], Row = i, Col = j });
                }
            }

            mainTable.ItemsSource = lsts;

            //Матрица для возведения в степень
            MyMatrix tempMatrix = incidenceMatrix;
            //Матрица транзитивного замыкания
            MyMatrix TransClosureMatrix = incidenceMatrix;

            for(int i = 1; i < incidenceMatrix.N; i++)
            {
                tempMatrix = tempMatrix * incidenceMatrix;
                TransClosureMatrix = TransClosureMatrix + tempMatrix;
            }

            graph2.Clear();
            foreach (var node in graph.Nodes)
                graph2.Nodes.Add(node);

            foreach(var edge in graph.Edges)
            {
                edge.Stroke = Brushes.Black;
                graph2.Edges.Add(edge);
            }

            for(int i = 0; i < TransClosureMatrix.N; i++)
            {
                for(int j = 0; j < TransClosureMatrix.N; j++)
                {
                    if(TransClosureMatrix[i,j] == 1 && incidenceMatrix[i,j] !=1 && i != j)
                    {
                        var edgeN = new Edge { A = graph.Nodes[i], B = graph.Nodes[j]};
                        edgeN.Stroke = Brushes.Red;
                        graph2.Edges.Add(edgeN);
                    }
                }
            }
        }      

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void MainTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ;
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = (sender as Border).DataContext as Cell;
            if (cell.Row == cell.Col) return;
            var value = 1 - cell.Value;
            if (value == 1)
                graph.AddEdge(cell.Row, cell.Col);
            else 
                graph.RemoveEdge(cell.Row, cell.Col);
            lsts[cell.Col][cell.Row].Value = cell.Value = value;

            TransitiveClosure();
        }
    }

    class Cell : INotifyPropertyChanged
    {
        int value;
        public int Row, Col;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
    }
}
