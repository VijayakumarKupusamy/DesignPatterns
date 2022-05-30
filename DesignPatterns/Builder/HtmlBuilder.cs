using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class HtmlBuilder
    {
        private readonly String RootName;

        private HtmlElement Root = new HtmlElement();
        public HtmlBuilder(String rootName)
        {
            this.RootName = rootName;
            Root.Name = rootName;
        }

        public void AddChild(String childName,String childText)
        {
            var e= new HtmlElement(childName,childText);
            Root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(String childName,String childText)
        {
            var e= new HtmlElement(childName,childText);
            Root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return Root.ToString(); 
        }

        public void Clear()
        {
            Root = new HtmlElement()
            {
                Name= RootName,
            };
        }
    }
}
