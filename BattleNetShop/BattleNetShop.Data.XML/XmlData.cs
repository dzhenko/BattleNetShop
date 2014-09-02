namespace BattleNetShop.Data.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;
    using System.Xml;
    using System.Globalization;

    public class XmlData : IXmlData
    {
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

        public IEnumerable<VendorExpense> GetAllVendorExpenses()
        {
            var allVendorExpenses = new List<VendorExpense>();

            /*var sampleVendorExpense = new VendorExpense();
            sampleVendorExpense.Date = DateTime.ParseExact("Jan-2014", "MMM yyyy", CultureInfo.InvariantCulture);
            sampleVendorExpense.Ammount = 70000;
            sampleVendorExpense.VendorName = "Blizzard";*/

            // TODO moove to method in XMLHandler that returns XmlNodeList vendorNodesList
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../InitialData/VendorExpensesInitialData.xml");
            // TODO don't select root node
            XmlNode root = doc.SelectSingleNode("/expenses-by-month");
            XmlNodeList vendorNodesList = root.SelectNodes("vendor");
            foreach (XmlNode vendorNode in vendorNodesList)
            {
                //VendorExpense vendorExpense = new VendorExpense();
                string vendorName = vendorNode.Attributes.GetNamedItem("name").Value;
                XmlNodeList vendorExpenses = vendorNode.SelectNodes("expenses");
                foreach (XmlNode expense in vendorExpenses)
                {
                    VendorExpense vendorExpense = new VendorExpense();
                    vendorExpense.VendorName = vendorName;
                    // TODO validate
                    vendorExpense.Ammount = decimal.Parse(expense.InnerText, CultureInfo.InvariantCulture);
                    vendorExpense.Date = DateTime.ParseExact(expense.Attributes.GetNamedItem("month").Value, "MMM-yyyy", CultureInfo.InvariantCulture);
                    allVendorExpenses.Add(vendorExpense);
                }
            }

            
            return allVendorExpenses;
        }

        /*
<?xml version="1.0" encoding="utf-8"?>
<expenses-by-month>
  <vendor name="Blizzard">
    <expenses month="Jan-2014">7000.00</expenses>
    <expenses month="Feb-2014">6000.00</expenses>
    <expenses month="Mar-2014">5000.00</expenses>
    <expenses month="Apr-2014">5000.00</expenses>
    <expenses month="May-2014">4000.00</expenses>
    <expenses month="Jun-2014">3000.00</expenses>
    <expenses month="Jul-2014">3000.00</expenses>
    <expenses month="Aug-2014">4000.00</expenses>
    <expenses month="Sep-2014">4000.00</expenses>
    <expenses month="Oct-2014">5000.00</expenses>
    <expenses month="Nov-2014">6000.00</expenses>
    <expenses month="Dec-2014">7000.00</expenses>
  </vendor>
  <vendor name="Angry Korean Guy">
    <expenses month="Jan-2014">700.00</expenses>
    <expenses month="Feb-2014">600.00</expenses>
    <expenses month="Mar-2014">500.00</expenses>
    <expenses month="Apr-2014">500.00</expenses>
    <expenses month="May-2014">400.00</expenses>
    <expenses month="Jun-2014">300.00</expenses>
    <expenses month="Jul-2014">300.00</expenses>
    <expenses month="Aug-2014">400.00</expenses>
    <expenses month="Sep-2014">400.00</expenses>
    <expenses month="Oct-2014">500.00</expenses>
    <expenses month="Nov-2014">600.00</expenses>
    <expenses month="Dec-2014">700.00</expenses>
  </vendor>
  <vendor name="Poor Bulgarian Gamer">
    <expenses month="Jan-2014">1.99</expenses>
    <expenses month="Feb-2014">1.99</expenses>
    <expenses month="Mar-2014">1.99</expenses>
    <expenses month="Apr-2014">1.99</expenses>
    <expenses month="May-2014">1.99</expenses>
    <expenses month="Jun-2014">1.99</expenses>
    <expenses month="Jul-2014">1.99</expenses>
    <expenses month="Aug-2014">1.99</expenses>
    <expenses month="Sep-2014">1.99</expenses>
    <expenses month="Oct-2014">1.99</expenses>
    <expenses month="Nov-2014">1.99</expenses>
    <expenses month="Dec-2014">1.99</expenses>
  </vendor>
  <vendor name="StarCraft Pro">
    <expenses month="Jan-2014">30.00</expenses>
    <expenses month="Feb-2014">30.00</expenses>
    <expenses month="Mar-2014">30.00</expenses>
    <expenses month="Apr-2014">40.00</expenses>
    <expenses month="May-2014">30.00</expenses>
    <expenses month="Jun-2014">30.00</expenses>
    <expenses month="Jul-2014">30.00</expenses>
    <expenses month="Aug-2014">40.00</expenses>
    <expenses month="Sep-2014">30.00</expenses>
    <expenses month="Oct-2014">30.00</expenses>
    <expenses month="Nov-2014">30.00</expenses>
    <expenses month="Dec-2014">40.00</expenses>
  </vendor>
  <vendor name="South Park Gang">
    <expenses month="Jan-2014">150.00</expenses>
    <expenses month="Feb-2014">150.00</expenses>
    <expenses month="Mar-2014">150.00</expenses>
    <expenses month="Apr-2014">150.00</expenses>
    <expenses month="May-2014">150.00</expenses>
    <expenses month="Jun-2014">150.00</expenses>
    <expenses month="Jul-2014">150.00</expenses>
    <expenses month="Aug-2014">150.00</expenses>
    <expenses month="Sep-2014">150.00</expenses>
    <expenses month="Oct-2014">150.00</expenses>
    <expenses month="Nov-2014">150.00</expenses>
    <expenses month="Dec-2014">150.00</expenses>
  </vendor>
</expenses-by-month>
         */
    }
}
