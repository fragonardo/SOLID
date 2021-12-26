using System.Collections.Generic;

namespace Composite.Core
{
    public interface IMenuComponent
    {    
        string Text {get; set;}
        string NavigationUrl {get; set;}
        IList<IMenuComponent> Children {get; set;}
    }
}
