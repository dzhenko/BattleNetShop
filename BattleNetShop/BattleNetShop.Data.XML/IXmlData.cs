namespace BattleNetShop.Data.Xml
{
    using System.Collections.Generic;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public interface IXmlData
    {
        IEnumerable<VendorExpense> GetAllVendorExpenses();

        void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports);
    }
}
