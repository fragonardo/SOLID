namespace Factory_Method.Core
{
    public class ChartProviderFree : IChartProvider
    {
        public IChart GetChart()
        {
            return new BarChart();
        }
    }
}