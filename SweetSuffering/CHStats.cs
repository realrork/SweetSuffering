namespace SweetSuffering
{
    public class CHStats : StatsAbstract
    {
        public CHStats() : base() { }

        private string chFile = SweetSufferingConfig.CHValuesFile;
        
        public override (int, int, float) GetStats(int period) 
        {
            Period = period;
            LoadStatsFromFile(chFile);
            return (Min, Max, Average);
        }
    }
}
