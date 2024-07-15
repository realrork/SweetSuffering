using SweetSuffering;

internal class Program
{
    private static void Main()
    {
        Messages.ShowWelcone();

        while (true)
        {

            string input = Messages.ShowMainMenu();

            if (input == "q")
            {
                break;
            }
            else if (input == "1")
            {
                GlucoseReceiverToFile glucoseReceiver = new GlucoseReceiverToFile();
                Console.Write("Wpisz zmierzony poziom glukozy: ");
                string? value = Console.ReadLine();
                try
                {
                    glucoseReceiver.AddMeasurement(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else if (input == "2")
            {
                InsulinReceiverToFile insulinReceiver = new InsulinReceiverToFile();
                Console.Write("Wpisz ilość zaaplikowanej insuliny: ");
                string? value = Console.ReadLine();
                try
                {
                    insulinReceiver.AddMeasurement(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (input == "3")
            {
                CHReceiverToFile chReceiver = new CHReceiverToFile();
                Console.Write("Wpisz ilość indeksu glikemicnego posiłku: ");
                string? value = Console.ReadLine();
                try
                {
                    chReceiver.AddMeasurement(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (input == "4")
            {
                while (true)
                {                    
                    string statsInput = Messages.ShowStatsMenu();
                    GlucoseStats glucoseStats = new GlucoseStats();
                    InsulinStats insulinStats = new InsulinStats();
                    CHStats chStats = new CHStats();

                    if (statsInput == "q")
                    {
                        break;
                    }
                    else if (statsInput == "1")
                    {
                        Messages.ShowStatistics(glucoseStats.GetStats(7), insulinStats.GetStats(7), chStats.GetStats(7));
                    }
                    else if (statsInput == "2")
                    {
                        Messages.ShowStatistics(glucoseStats.GetStats(30), insulinStats.GetStats(30), chStats.GetStats(30));
                    }
                    else if (statsInput == "3")
                    {
                        Messages.ShowStatistics(glucoseStats.GetStats(60), insulinStats.GetStats(60), chStats.GetStats(60));

                    }
                }
            }
            else
            {
                Console.Clear();
            }
        }
    }
}