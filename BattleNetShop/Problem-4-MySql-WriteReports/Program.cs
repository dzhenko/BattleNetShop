namespace Problem_4_MySql_WriteReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.MySqlTelerikDA;
    class Program
    {
        static void Main()
        {
            MySqlTelerikHandler reportWriter = new MySqlTelerikHandler();
            reportWriter.WriteReport(2, "AwesomeItem", "Blizzard", 111, 222);
        }
    }
}
