using Microsoft.Extensions.Configuration;

namespace AATNumbersApp.BLL
{
    public static class StaticClass
    {
        public static class GlobalVariable
        {
            public static List<int> Numbers { get; set; } = [];

            public static int TotalOddNumbers { get; set; } = 0;

            public static int TotalEvenNumbers { get; set; } = 0;

            public static int Take { get; set; } = 1000000;

            public static int MinCounter { get; set; } = 2500000;

            public static int MaxCounter { get; set; } = 10000000;

            public static bool IsEvenNumbersThreadCreated { get; set; } = false;
        }

        public static class DatabaseHelper
        {
            public static void InitializeApplicationSettings(IConfiguration configuration)
            {
                if (Data.StaticClass.DatabaseHelper.ConnectionString != null)
                    return;
                Data.StaticClass.DatabaseHelper.ConnectionString = configuration["ConnectionStrings:DatabasePath"];
            }
        }
    }
}
