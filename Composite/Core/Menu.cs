using System.Collections.Generic;

namespace Composite.Core
{
    public class Menu 
    {
        public string Text {get; set;}        
        public string NavigationUrl {get; set;}
        public IList<IMenuComponent> Children {get; set;}        
        public bool OpenInWindow {get; set;}

        public Menu()
        {
            this.Children = new List<IMenuComponent>();
        }
    }
}