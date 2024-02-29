using System.IO.Enumeration;
using static System.Formats.Asn1.AsnWriter;

namespace SweetSuffering
{
    public abstract class ReceiverToFileAbstract
    {
        public delegate void MeasurementAddedDelegate(object sender, MeasurementLevel args);
        public abstract event MeasurementAddedDelegate MeasurementAdded;

        public ReceiverToFileAbstract(string fileName, int minMeasurement, int maxMeasurement)
        {
            FileName = fileName;
            Date = DateTime.Now;
            Measurement = 0;
            MinMeasurement = minMeasurement;
            MaxMeasurement = maxMeasurement;
            MeasurementAdded += MeasurementAddedBase;
        }

        public string FileName { get; private set; }
        public DateTime Date { get; private set; }
        public int Measurement { get; private set; }
        public int MinMeasurement { get; private set; }
        public int MaxMeasurement { get; private set; }

        public void MeasurementAddedBase(object sender, MeasurementLevel args)
        {
            Messages.Succes("Pomiar zapisany do pliku.");
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
