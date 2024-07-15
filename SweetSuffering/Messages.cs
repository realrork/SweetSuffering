namespace SweetSuffering
{
    public static class Messages
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string ShowMainMenu()
        {
            Console.WriteLine("\n1. Wprowadź pomiar poziomu glukozy");
            Console.WriteLine("2. Wprowadź ilość zaaplikowanej insuliny");
            Console.WriteLine("3. Wprowadź indeks glikemiczny posiłku");
            Console.WriteLine("4. Przejrzyj tylko statystyki");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("q. Zakończ program\n");
            Console.Write("Twój wybór: ");
            var input = Console.ReadLine();
            return input;
        }

        public static string ShowStatsMenu()
        {
            Console.WriteLine("\nWybierz okres, za który mają być zliczone statystyki:");
            Console.WriteLine("1. 7 ostatnich wpisów");
            Console.WriteLine("2. 30 ostatnich wpisów");
            Console.WriteLine("3. 60 ostatnich wpisów");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("q. Anuluj i przejdź do głównego menu\n");
            Console.Write("Twój wybór: ");
            var input = Console.ReadLine();
            return input;
        }

        public static void ShowWelcone()
        {
            Console.WriteLine("Witaj w programie 'Dziennik Słodziaka'.");
            Console.WriteLine("Wybierz jaki rodzaj informacji chcesz ");
            Console.WriteLine("wprowadzić. Po wprowadzeniu informacji ");
            Console.WriteLine("zostaną wyświetlone statystki.");
            Console.WriteLine("========================================");
        }

        public static void ShowStatistics((int, int, float) gStats, (int, int, float) iStats, (int, int, float) cStats )
        {
            
            (int ming, int maxg, float avgg) = gStats;
            (int mini, int maxi, float avgi) = iStats;
            (int minc, int maxc, float avgc) = cStats;

            Console.WriteLine("Twoje statystyki cukrów, insuliny i węglowodanów");
            Console.WriteLine("================================================");
            Console.WriteLine($"|    Glukoza  |    min: {ming}, max: {maxg}, średnia: {Math.Round(avgg, 2)}");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"|   Insulina  |    min: {mini}, max: {maxi}, średnia: {Math.Round(avgi, 2)}");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"| Węglowodany |    min: {minc}, max: {maxc}, średnia: {Math.Round(avgc, 2)}");
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
