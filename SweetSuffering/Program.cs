using SweetSuffering;

internal class Program
{
    private static void Main()
    {


        while (true)
        {

            string input = Messages.ShowMenu();

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
            else if (input == "2") { }
            else if (input == "3") { }
            else if (input == "4") { }
            else
            {
                Console.Clear();
            }
        }
    }
}