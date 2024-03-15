namespace SweetSuffering
{
    public class MeasurementEventArgs : EventArgs
    {
        public int Level { get; set; }

        public MeasurementEventArgs(int level)
        {
            Level = level;
        }
    }
}
