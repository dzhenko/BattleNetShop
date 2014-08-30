namespace Problem_4_GenerateJSONFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.JSON;
    class Program
    {
        static void Main()
        {
            new JSONHandler().GenerateJSONFileReports();
        }
    }
}
