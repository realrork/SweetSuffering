namespace SweetSuffering
{
    public abstract class MeasureAbstract
    {
        public delegate void MeasurementAddedDelegate(object sender, MeasurementEventArgs args);
        public abstract event MeasurementAddedDelegate MeasurementAdded;

        public MeasureAbstract(int minMeasurement, int maxMeasurement)
        {
            Date = DateTime.Now;
            Measurement = 0;
            MinMeasurement = minMeasurement;
            MaxMeasurement = maxMeasurement;
            MeasurementAdded += MeasurementAddedBase;
        }

        public DateTime Date { get; private set; }
        public int Measurement { get; private set; }
        public int MinMeasurement { get; private set; }
        public int MaxMeasurement { get; private set; }

        public void MeasurementAddedBase(object sender, MeasurementEventArgs args)
        {
            Console.Write("Pomiar zweryfikowany - ");
        }

        public virtual void AddMeasurement(string measurement) { }

        protected int ValidateMeasurement(string measurement)
        {
            if (int.TryParse(measurement, out int result))
            {
                if (result < MinMeasurement || result > MaxMeasurement)
                {
                    throw new ArgumentException("Podana wartość jest nieprawidłowa!");
                }
                else
                {
                    return result;
                }
            }
            else
            {
                throw new Exception("Wpisana wartość nie jest liczbą!");
            }
        }
    }
}
