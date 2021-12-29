
using System.Collections.Generic;
using System.Drawing;

namespace Factory_Method.Core
{
    public interface IChart
    {
         string Title {get; set;}
         IList<string> XData {get;set;}
         IList<int> YData {get;set;}

         Color[] colors {get; set;}

         Bitmap GenerateChart();
    }
}