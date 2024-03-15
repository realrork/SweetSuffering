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
                    Statistics stats = new Statistics();
                    string statsInput = Messages.ShowStatsMenu();

                    if (statsInput == "q")
                    {
                        break;
                    }
                    else if (statsInput == "1")
                    {
                        Messages.ShowStatistics(stats.GetStatistic(7));
                    }
                    else if (statsInput == "2")
                    {
                        Messages.ShowStatistics(stats.GetStatistic(30));
                    }
                    else if (statsInput == "3")
                    {
                        Messages.ShowStatistics(stats.GetStatistic(60));
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