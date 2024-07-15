namespace SweetSuffering
{
    internal class CHReceiverToFile : ReceiverToFileAbstract
    {
        private string fileName = SweetSufferingConfig.CHValuesFile;

        public CHReceiverToFile()
            : base(SweetSufferingConfig.MinCH, SweetSufferingConfig.MaxCH)
        {
            MeasurementAdded += CHAddedInFile;
        }

        private void CHAddedInFile(object sender, MeasurementEventArgs args)
        {
            switch(args.Level)
            {
                case > 150:
                    Messages.Warning("Zapisano ilość węglowodanów, ale pomyśl nad zmianą diety!");
                    break;                
                default:
                    Messages.Success("Zapisano indeks glikemiczny.");
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
                    throw new Exception("Wystąpił błąd podczas zapisu danych do pliku!");
                }
            }
        }
    }    
}
