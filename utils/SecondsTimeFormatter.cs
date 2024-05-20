using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;


namespace MEPSortingAlgorithms.utils
{
    public class SecondsTimeFormatter : IColumn
    {
        public string Id => nameof(SecondsTimeFormatter);
        public string ColumnName => "Mean (s)";

        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Statistics;
        public int PriorityInCategory => 1;
        public bool IsNumeric => true;
        public UnitType UnitType => UnitType.Time;
        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
        public string Legend => "Mean time in seconds";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var mean = summary[benchmarkCase].ResultStatistics.Mean;
            var seconds = TimeInterval.FromNanoseconds(mean).ToSeconds();
            return seconds.ToString("0.0000");
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
        {
            return GetValue(summary, benchmarkCase);
        }

        public bool IsAvailable(Summary summary) => true;

        public bool GetIsDefault()
        {
            return false;
        }
    }
}
