namespace Factory_Method.Core
{
    public class ChartProviderPaid : IChartProvider
    {
        public IChart GetChart()
        {
            return new PieChart();
        }
    }
}