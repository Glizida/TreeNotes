using System;
using System.Collections.Generic;
using System.Text;

namespace TreeNotes.Class
{
    public class TreeDate<T>
    {
        private string header;
        private string tag;
        private string text;
        private T data;

        public TreeDate(string header, string tag, string text, T data)
        {
            this.header = header;
            this.tag = tag;
            this.text = text;
            this.data = data;
        }
        
        public TreeDate(string header, string tag, string text)
        {
            this.header = header;
            this.tag = tag;
            this.text = text;
        }
        
        public TreeDate(string header, string tag)
        {
            this.header = header;
            this.tag = tag;
        }

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Tag
        {
            get => tag;
            set => tag = value;
        }

        public string Text
        {
            get => text;
            set => text = value;
        }

        public T Data
        {
            get => data;
            set => data = value;
        }
    }
}
