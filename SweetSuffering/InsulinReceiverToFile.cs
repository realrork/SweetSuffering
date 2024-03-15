namespace SweetSuffering
{
    internal class InsulinReceiverToFile : ReceiverToFileAbstract
    {
        private string fileName = SweetSufferingConfig.InsulinValuesFile;

        public InsulinReceiverToFile()
            : base(SweetSufferingConfig.MinInsulin, SweetSufferingConfig.MaxInsulin)
        {
            MeasurementAdded += InsulinAddedInFile;
        }

        private void InsulinAddedInFile(object sender, MeasurementEventArgs args)
        {
            switch(args.Level)
            {
                case > 30:
                    Messages.Warning("Zapisano dawkę insuliny, ale wygląda ona na zbyt dużą!");
                    break;                
                default:
                    Messages.Success("Zapisano zaaplikowaną dawkę insluiny.");
                    break;
            }
        }

        public new int Measurement { get; private set; }

        public override event MeasurementAddedDelegate MeasurementAdded;

        public override void AddMeasurement(string measurement)
        {
            Measurement = ValidateMeasurement(measurement);
            string valueToWrite = $"{Date};{Measurement}";
            using (var writer = File.AppendText(fileName))
            {
                try
                {
                    writer.WriteLine(valueToWrite);
                    if (MeasurementAdded != null)
                    {                        
                        MeasurementAdded(this, new MeasurementEventArgs(Measurement));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Wystąpił błąd podczas zapisu danych do pliku");
                }
            }
        }
    }    
}
