namespace BattleNetShop.Client
{
    using System;
    using System.Linq;

    using BattleNetShop.Logic;

    public class ConsoleClient
    {
        public static void Main()
        {
            new DataSeeder().Seed();

            new ExcelReportsLoader().Load();

            //new PdfReportsGenerator().Generate();

            //new JsonReportsGenerator().Generate();

            new MySqlReportsLoader().Load();
            //// new XmlReportsHandler().Generate();
        }
    }
}
