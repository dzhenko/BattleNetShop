namespace BattleNetShop.Data.Xml
{
    using System.Collections.Generic;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;
    using System.Xml;
    using System.Globalization;
    using BattleNetShop.Logic;

    public class XmlData : IXmlData
    {
        public IEnumerable<VendorExpense> GetAllVendorExpenses()
        {
            var allVendorExpenses = new List<VendorExpense>();
            IBattleNetShopSqlServerData msSqlData;

            // foreach vendor name
                // foreach expense
            //allVendorExpenses.Add(new VendorExpense() 
            //{
            //    VendorName = name,
            //    Month = expense.Month,
            //    Ammount = expense.Amount
            //});

            return allVendorExpenses;
        }

        /*
<?xml version="1.0" encoding="utf-8">
<expenses-by-month>
  <vendor name="Nestle Sofia Corp.">
    <expenses month="Jul-2013">30.00</expenses>
    <expenses month="Aug-2013">40.00</expenses>
  </vendor>
  <vendor name="Targovishte Bottling Company Ltd.">
    <expenses month="Jul-2013">200.00</expenses>
    <expenses month="Aug-2013">180.00</expenses>
  </vendor>
  <vendor name="Zagorka Corp.">
    <expenses month="Jul-2013">120.00</expenses>
    <expenses month="Aug-2013">180.00</expenses>
  </vendor>
<expenses-by-month>
         */

        public void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports)
        {
            // TODO moove some functionality to XmlHandler
            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement("sales");
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            foreach (LocationReport locationReport in locationReports)
            {
                XmlElement sale = report.CreateElement("location");
                sale.SetAttribute("name", locationReport.LocationName);
                root.AppendChild(sale);
                foreach (LocationReportEntry entry in locationReport.Entries)
                {
                    XmlElement summary = report.CreateElement("summary");
                    summary.SetAttribute("date", entry.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    summary.SetAttribute("total-sum", entry.TotalSum.ToString());
                    sale.AppendChild(summary);
                }
            }
            report.Save("../../../../Reports/XmlReports/XML-all-locations-report.xml");
        }
        /*
<?xml version="1.0" encoding="utf-8">
<sales>
  <location name="location name here">
    <summary date="20-Jul-2013" total-sum="54.75" />
    <summary date="21-Jul-2013" total-sum="40.35" />
    <summary date="22-Jul-2013" total-sum="40.60" />
  </location>
  <location name="Targovishte Bottling Company Ltd.">
    <summary date="20-Jul-2013" total-sum="150.20" />
    <summary date="21-Jul-2013" total-sum="709.30" />
    <summary date="22-Jul-2013" total-sum="249.40" />
  </location>
  <location name="Zagorka Corp.">
    <summary date="20-Jul-2013" total-sum="144.80" />
    <summary date="21-Jul-2013" total-sum="341.59" />
    <summary date="22-Jul-2013" total-sum="385.80" />
  </location>
         */
    }
}
