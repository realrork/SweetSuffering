namespace SweetSuffering
{
    public static class SweetSufferingConfig
    {
        public static string GlucoseValuesFile { get { return "glucose-diary.txt"; } }
        public static string InsulinValuesFile { get { return "insulin-diary.txt"; } }
        public static string CHValuesFile { get { return "ch-diary.txt"; } }
        public static int MinGlucose { get { return 0; } }
        public static int MaxGlucose { get { return 999; } }
        public static int MinInsulin { get { return 1; } }
        public static int MaxInsulin { get { return 100; } }
        public static int MinCH { get { return 0; } }
        public static int MaxCH { get { return 500; } }
    }
}
