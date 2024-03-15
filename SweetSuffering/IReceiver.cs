using static SweetSuffering.ReceiverToFileAbstract;

namespace SweetSuffering
{
    public interface IReceiver
    {
        string FileName { get; }
        DateTime Date { get; }
        int Measurement { get; }
        int MinMeasurement { get; }
        int MaxMeasurement { get; }        

        event MeasurementAddedDelegate MeasurementAdded;

        void AddMeasurement(string measurement);
        int ValidateMeasurement(string measurement);
    }
}
