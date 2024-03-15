namespace SweetSuffering
{
    public class Statistics
    {
        private string glucoseFile = SweetSufferingConfig.GlucoseValuesFile;
        private string insulinFile = SweetSufferingConfig.InsulinValuesFile;
        private string chFile = SweetSufferingConfig.CHValuesFile;
        public Statistics()
        {

            MaxGlucose = SweetSufferingConfig.MinGlucose;
            MinGlucose = SweetSufferingConfig.MaxGlucose;
            AverageGlucose = 0;

            MaxInsulin = SweetSufferingConfig.MinInsulin;
            MinInsulin = SweetSufferingConfig.MaxInsulin;
            AverageInsulin = 0;

            MaxCH = SweetSufferingConfig.MinCH;
            MinCH = SweetSufferingConfig.MaxCH;
            AverageCH = 0;
        }

        private int MaxGlucose { get; set; }
        private int MinGlucose { get; set; }
        private int MaxInsulin { get; set; }
        private int MinInsulin { get; set; }
        private int MaxCH { get; set; }
        private int MinCH { get; set; }
        private int Period { get; set; }
        private float AverageGlucose { get; set; }
        private float AverageInsulin { get; set; }
        private float AverageCH { get; set; }

        private void LoadGlucoseDataFromFiles()
        {
            int counter = 0;
            int sum = 0;

            if (File.Exists(glucoseFile))
            {
                using (var reader = File.OpenText(glucoseFile))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] chunks = line.Split(';');
                        if (chunks.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(chunks[0]))
                            {
                                if (DateTime.TryParse(chunks[0], out DateTime date))
                                {
                                    TimeSpan timeSpan = DateTime.Now - date;
                                    if (timeSpan.Days < Period)
                                    {
                                        if (int.TryParse(chunks[1], out int value))
                                        {
                                            if (value < MinGlucose)
                                            {
                                                MinGlucose = value;
                                            }
                                            if (value > MaxGlucose)
                                            {
                                                MaxGlucose = value;
                                            }
                                            sum += value;
                                            counter++;
                                        }
                                        else
                                        {
                                            throw new Exception($"W pliku {glucoseFile} znajdują nieprawidłowe dane!");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"W pliku {glucoseFile} znajdują nieprawidłowe daty!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception($"W pliku {glucoseFile} znajduje się nieprawidłowy wpis!");
                        }
                        line = reader.ReadLine();
                    }                    
                }
                AverageGlucose = (float)sum / (float)counter;
            }
        }
        
        private void LoadInsulinDataFromFiles()
        {
            int counter = 0;
            int sum = 0;

            if (File.Exists(insulinFile))
            {
                using (var reader = File.OpenText(insulinFile))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] chunks = line.Split(';');
                        if (chunks.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(chunks[0]))
                            {
                                if (DateTime.TryParse(chunks[0], out DateTime date))
                                {
                                    TimeSpan timeSpan = DateTime.Now - date;
                                    if (timeSpan.Days < Period)
                                    {
                                        if (int.TryParse(chunks[1], out int value))
                                        {
                                            if (value < MinInsulin)
                                            {
                                                MinInsulin = value;
                                            }
                                            if (value > MaxInsulin)
                                            {
                                                MaxInsulin = value;
                                            }
                                            sum += value;
                                            counter++;
                                        }
                                        else
                                        {
                                            throw new Exception($"W pliku {insulinFile} znajdują nieprawidłowe dane!");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"W pliku {insulinFile} znajdują nieprawidłowe daty!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception($"W pliku {insulinFile} znajduje się nieprawidłowy wpis!");
                        }
                        line = reader.ReadLine();
                    }
                }
                AverageInsulin = (float)sum / (float)counter;
            }
        }

        private void LoadCHDataFromFiles()
        {
            int counter = 0;
            int sum = 0;

            if (File.Exists(chFile))
            {
                using (var reader = File.OpenText(chFile))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] chunks = line.Split(';');
                        if (chunks.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(chunks[0]))
                            {
                                if (DateTime.TryParse(chunks[0], out DateTime date))
                                {
                                    TimeSpan timeSpan = DateTime.Now - date;
                                    if (timeSpan.Days < Period)
                                    {
                                        if (int.TryParse(chunks[1], out int value))
                                        {
                                            if (value < MinCH)
                                            {
                                                MinCH = value;
                                            }
                                            if (value > MaxCH)
                                            {
                                                MaxCH = value;
                                            }
                                            sum += value;
                                            counter++;
                                        }
                                        else
                                        {
                                            throw new Exception($"W pliku {chFile} znajdują nieprawidłowe dane!");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"W pliku {chFile} znajdują nieprawidłowe daty!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception($"W pliku {chFile} znajduje się nieprawidłowy wpis!");
                        }
                        line = reader.ReadLine();
                    }
                }
                AverageCH = (float)sum / (float)counter;
            }
        }

        public (int, int, float, int, int, float, int, int, float) GetStatistic(int period)
        {
            Period = period;
            LoadGlucoseDataFromFiles();
            LoadInsulinDataFromFiles();
            LoadCHDataFromFiles();
            return (MinGlucose, MaxGlucose, AverageGlucose, MinInsulin, MaxInsulin, AverageInsulin, MinCH, MaxCH, AverageCH);
        }
    }
}
