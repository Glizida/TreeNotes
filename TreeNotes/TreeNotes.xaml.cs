using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace TreeNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        [Serializable]
        public class Node
        {
            public string Name { get; set; }
            public ObservableCollection<Node> Nodes { get; set; }

            public Node(string name, ObservableCollection<Node> nodes)
            {
                Name = name;
                Nodes = nodes;
            }

            public Node()
            {
            }
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
            
            XmlSerializer formatter = new XmlSerializer(typeof(Node));
            using (FileStream fs = new FileStream("wons.xml", FileMode.Create))
            {
                formatter.Serialize(fs, nodes);
            }

            TreeViewNotes.ItemsSource = nodes;
        }
    }
}
