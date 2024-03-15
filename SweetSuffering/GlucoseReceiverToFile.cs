namespace SweetSuffering
{
    internal class GlucoseReceiverToFile : ReceiverToFileAbstract
    {
        private string fileName = SweetSufferingConfig.GlucoseValuesFile;

        public GlucoseReceiverToFile()
            : base(SweetSufferingConfig.MinGlucose, SweetSufferingConfig.MaxGlucose)
        {
            MeasurementAdded += GlucoseAddedInFile;
        }

        private void GlucoseAddedInFile(object sender, MeasurementEventArgs args)
        {
            switch(args.Level)
            {
                case < 40:
                    Messages.Error("Twój poziom cukru jest bardzo niski! Natychmiast zjedz lub wypij coś słodkiego!");
                    break;
                case > 200:
                    Messages.Error("Twój poziom cukru jest bardzo wysoki!");
                    break;
                case int i when (i >= 40 && i <= 60):
                    Messages.Warning("Twój poziom cukru jest niski!");
                    break;
                case int i when (i >= 180 && i < 200):
                    Messages.Warning("Twój poziom cukru jest za wysoki!");
                    break;
                case int i when (i > 60 && i <= 100):
                    Messages.Success("Gratulacje! Poziom cukru w normie :)");
                    break;
                default:
                    Messages.Success("Gratulacje! Jak na cukrzyka dobry poziom cukru :)");
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
                    MeasurementAdded?.Invoke(this, new MeasurementEventArgs(Measurement));
                }
                catch (Exception ex)
                {
                    throw new Exception("Wystąpił błąd podczas zapisu danych do pliku");
                }
            }
        }
    }    
}
