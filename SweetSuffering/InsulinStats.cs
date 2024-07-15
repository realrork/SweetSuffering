namespace SweetSuffering
{
    public class InsulinStats : StatsAbstract
    {
        public InsulinStats() : base() { }

        private string insulinFile = SweetSufferingConfig.InsulinValuesFile;

        
        public override (int, int, float) GetStats(int period) 
        {
            Period = period;
            LoadStatsFromFile(insulinFile);
            return (Min, Max, Average);
        }
    }
}
