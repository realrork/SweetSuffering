using System.ComponentModel.DataAnnotations;

namespace SweetSuffering
{
    public abstract class StatsAbstract
    {
        public StatsAbstract()
        {
            Min = 0;
            Max = 0;
            Average = 0;
            Period = 0;
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public float Average { get; set; }
        public int Period { get; set; }

        public virtual void LoadStatsFromFile(string file)
        {
            int counter = 0;
            int sum = 0;

            if (File.Exists(file))
            {
                using (var reader = File.OpenText(file))
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
                                            if (counter == 0)
                                            {
                                                Min = Max = value;
                                            }
                                            else
                                            {
                                                if (value > Max)
                                                {
                                                    Max = value;
                                                }
                                                if (value < Min)
                                                {
                                                    Min = value;
                                                }
                                            }

                                            sum += value;
                                            counter++;
                                        }
                                        else
                                        {
                                            throw new Exception($"W pliku {file} znajdują nieprawidłowe dane!");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"W pliku {file} znajdują nieprawidłowe daty!");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception($"W pliku {file} znajduje się nieprawidłowy wpis!");
                        }
                        line = reader.ReadLine();
                    }
                }
                Average = (float)sum / (float)counter;
            }
        }
        public virtual (int, int, float) GetStats(int period)
        {
            Period = period;
            return (Min, Max, Average);
        }
    }
}
