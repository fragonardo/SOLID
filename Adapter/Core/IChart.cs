using System.Collections.Generic;
using System.Drawing;

namespace Adapter.Core
{
    public interface IChart
    {
        string Title {get; set;}
        IList<string> XData {get; set;}
        IList<int> YData {get; set;}
        Bitmap GenerateChart();
    }
}