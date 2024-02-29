namespace SweetSuffering
{
    public static class Messages
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Succes(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string ShowMenu()
        {
            Console.WriteLine("Witaj w programie 'Dziennik Słodziaka'.");
            Console.WriteLine("Wybierz jaki rodzaj informacji chcesz ");
            Console.WriteLine("wprowadzić. Po wprowadzeniu informacji ");
            Console.WriteLine("zostaną wyświetlone statystki.");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Wprowadź pomiar poziomu glukozy");
            Console.WriteLine("2. Wprowadź ilość zaaplikowanej insuliny");
            Console.WriteLine("3. Wprowadź ilość węglowodanów w posiłku");
            Console.WriteLine("4. Przejrzyj tylko statystyki");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("q. Zakończ program\n");
            Console.Write("Twój wybór: ");
            var input = Console.ReadLine();
            return input;
        }
    }
}