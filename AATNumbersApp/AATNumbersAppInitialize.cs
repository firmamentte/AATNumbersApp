using AATNumbersApp.BLL;

namespace AATNumbersApp
{
    public static class AATNumbersAppInitialize
    {
        public static void InitializeApplicationSettings(this WebApplication app)
        {
            StaticClass.DatabaseHelper.InitializeApplicationSettings(app.Configuration);
        }
    }
}
