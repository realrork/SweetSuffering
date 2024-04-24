namespace SweetSuffering
{
    public abstract class GlucoseStats : StatsAbstract
    {
        public GlucoseStats(int period) : base(SweetSufferingConfig.MinGlucose, SweetSufferingConfig.MaxGlucose, period) { }

        private string glucoseFile = SweetSufferingConfig.GlucoseValuesFile;

        public override void LoadStatsFromFile()
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
                                    if (counter <= Period)
                                    {
                                        if (int.TryParse(chunks[1], out int value))
                                        {
                                            if (value < Min)
                                            {
                                                Min = value;
                                            }
                                            if (value > Max)
                                            {
                                                Max = value;
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
                Average = (float)sum / (float)counter;
            }
        }
        public override (int, int, float) GetStats() 
        {
            LoadStatsFromFile();
            return (Min, Max, Average);
        }
    }
}
