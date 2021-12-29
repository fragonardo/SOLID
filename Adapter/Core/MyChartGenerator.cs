using System.Collections.Generic;
using System.Drawing;

namespace Adapter.Core
{
    public class MyChartGenerator : IChart
    {
        public string Title {get; set;}
        public IList<string> XData {get; set;}
        public IList<int> YData {get; set;}
        public Bitmap GenerateChart()
        {
            return  null;
        }
    }
}