namespace SweetSuffering
{
    public class GlucoseStats : StatsAbstract
    {
        public GlucoseStats() : base() { }

        private string glucoseFile = SweetSufferingConfig.GlucoseValuesFile;

        
        public override (int, int, float) GetStats(int period) 
        {
            Period = period;
            LoadStatsFromFile(glucoseFile);
            return (Min, Max, Average);
        }
    }
}
