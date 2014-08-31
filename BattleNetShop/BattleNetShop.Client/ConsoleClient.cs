namespace BattleNetShop.Client
{
    using BattleNetShop.Logic;

    public class ConsoleClient
    {
        public static void Main()
        {
            new DataSeeder().Seed();

            new ExcelReportsLoader().Load();

            new ExcelReportsLoader().Test();
        }
    }
}
