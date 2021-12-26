using System.Collections.Generic;

namespace Composite.Core
{
    public class MenuComponent : IMenuComponent
    {
        public string Text {get; set;}
        public string NavigationUrl {get; set;}
        public IList<IMenuComponent> Children {get; set;}
    }
}