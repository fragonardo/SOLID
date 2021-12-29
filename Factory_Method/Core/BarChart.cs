using System.Collections.Generic;
using System.Drawing;
using System;

namespace Factory_Method.Core
{
    public class BarChart : IChart
    {
        public string Title {get; set;}
        public IList<string> XData {get;set;}
        public IList<int> YData {get;set;}

        public Color[] colors {get; set;}

        public Bitmap GenerateChart()
         {
            var chartBitmap = new Bitmap(400,200);
            var chartGraphics = Graphics.FromImage(chartBitmap);
            chartGraphics.Clear(Color.White);
            var titleFont = new Font("Arial",16);
            var titleXY = new PointF(5,5);
            chartGraphics.DrawString(this.Title,titleFont,Brushes.Black, titleXY);
            
            var spacing = 35;
            var scale = 10;
            var rand = new Random();

            for(var i = 0; i < this.YData.Count; i++ )
            {                
                var barBrush = new SolidBrush(colors[i]);
                var barX = (i * spacing) + 15;
                var barY = 200 - (YData[i] * scale);
                var barWidth = 20;
                var barHeight = (this.YData[i] * scale) + 5;
                chartGraphics.FillRectangle(barBrush, barX, barY, barWidth, barHeight);
                chartGraphics.DrawRectangle(Pens.Black, barX, barY, barWidth, barHeight);
            }

            var legendRect = new PointF(335, 20);
            var legendText = new PointF(360, 16);
            var legendFont = new Font("Arial", 10);

            for(var i = 0; i < this.XData.Count; i ++)
            {
                var legendBrush = new SolidBrush(colors[i]);
                chartGraphics.FillRectangle(legendBrush, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawRectangle(Pens.Black, legendRect.X, legendRect.Y, 20, 10);
                chartGraphics.DrawString(XData[i], legendFont, Brushes.Black, legendText);
                legendRect.Y += 15;
                legendText.Y += 15;
            }

            var borderPen = new Pen(Color.Black, 2);
            var borderRect = new Rectangle(1, 1, 398, 198);
            chartGraphics.DrawRectangle(borderPen, borderRect);


            return chartBitmap;
         }
    }
}