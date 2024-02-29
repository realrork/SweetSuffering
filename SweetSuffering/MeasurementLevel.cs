namespace SweetSuffering
{
    public class MeasurementLevel : EventArgs
    {
        public int Level { get; set; }

        public MeasurementLevel(int level)
        {
            Level = level;
        }
    }
}
