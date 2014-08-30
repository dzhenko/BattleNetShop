namespace BattleNetShop.Logic
{
    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.Data.MongoDb;

    public class DataSeeder
    {
        public void Seed()
        {
            new MongoDataSeeder().Seed();

            new ExcelZippedDataSeeder().Seed();
        }
    }
}
