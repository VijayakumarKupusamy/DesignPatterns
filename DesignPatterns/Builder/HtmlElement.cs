using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class HtmlElement
    {
        public String Name, Text;
        public List<HtmlElement> Elements= new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private String ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new String(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!String.IsNullOrWhiteSpace(Text))
            {
                sb.AppendLine(new string(' ', indentSize * (indent+1)));
                sb.Append(Text);
                sb.Append("\n");
            }
            foreach(var element in Elements)
            {
                sb.Append(element.ToStringImpl(indent+1));
            }
            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
