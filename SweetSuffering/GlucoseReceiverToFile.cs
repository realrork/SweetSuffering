namespace SweetSuffering
{
    internal class GlucoseReceiverToFile : ReceiverToFileAbstract
    {
        private const string fileName = "glucose-diary.txt";

        public GlucoseReceiverToFile()
            : base(fileName, 0, 999)
        {
            MeasurementAdded += GlucoseAddedInFile;
        }

        private void GlucoseAddedInFile(object sender, MeasurementLevel args)
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
                    Messages.Warning("Twój poziom cukru za wysoki!");
                    break;
                default:
                    Messages.Succes("Gratulacje! Jak na cukrzyka dobry poziom cukru :)");
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
                        MeasurementAdded(this, new MeasurementLevel(Measurement));
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
