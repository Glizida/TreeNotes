using System.Collections.ObjectModel;
using System.Windows;

namespace TreeNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public class Node
        {
            public string Name { get; set; }
            public ObservableCollection<Node> Nodes { get; set; }
        }

        ObservableCollection<Node> nodes;

        public MainWindow()
        {
            InitializeComponent();

            nodes = new ObservableCollection<Node>
            {
                new Node()
                {
                    Name = "Нода 1",
                    Nodes = new ObservableCollection<Node>
                    {
                        new Node()
                        {
                            Name = "Нода 2"
                        }
                    }
                },
                new Node()
                {
                    Name = "Нода 3"
                }
            };
            TreeViewNotes.ItemsSource = nodes;
        }
    }
}
