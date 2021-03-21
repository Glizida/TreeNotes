using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
            public string Text { get; set; }

            public Node(string name, ObservableCollection<Node> nodes)
            {
                Name = name;
                Nodes = nodes;
                Text = "";
            }

            public Node(string name, ObservableCollection<Node> nodes, string text)
            {
                Name = name;
                Nodes = nodes;
                Text = text;
            }


            public Node()
            {
                Text = "";
            }
        }

        ObservableCollection<Node> nodes;
        string Path = Environment.CurrentDirectory + "\\tree.json";

        Node selectNode;

        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //-------------------------Сохранение дерева и текста в файл--------------------------//

            string jsonOut = JsonConvert.SerializeObject(nodes);
            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(jsonOut);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //--------------------Загрузка дерева и текста из файла---------------------------//
            if (File.Exists(Path)) 
            {
                nodes = new ObservableCollection<Node> { };
                string jsonText = "";
                using (StreamReader sr = new StreamReader(Path))
                {
                    jsonText = sr.ReadToEnd();
                }
                nodes = JsonConvert.DeserializeObject<ObservableCollection<Node>>(jsonText);
                TreeView.ItemsSource = nodes;
            }
            else
            {
                File.Create(Path);
            }
               

        }

        private void TreeView_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //--------------------Загрузка текта привязанного к ноде---------------------------//
            selectNode = (Node)TreeView.SelectedItem;
            TextBox.Text = selectNode.Text;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //--------------------Изменение текта привязанного к ноде и его сохранения---------------------------//
            int index = nodes.IndexOf(selectNode);
            selectNode.Text = TextBox.Text;
            nodes[index] = selectNode;
            TreeView.ItemsSource = nodes;
            
        }
    }
}
