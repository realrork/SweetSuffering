using System.ComponentModel.DataAnnotations;

namespace SweetSuffering
{
    public abstract class StatsAbstract
    {        
        public StatsAbstract(int min, int max, int period)
        {
            Min = min;
            Max = max;
            Average = 0;
            Period = period;
        }

        public int Min {  get; set; }
        public int Max { get; set; }
        public float Average { get; set; }
        public int Period {  get; set; }

        public virtual void LoadStatsFromFile() { }
        public virtual (int, int, float) GetStats() { }
    }
}
