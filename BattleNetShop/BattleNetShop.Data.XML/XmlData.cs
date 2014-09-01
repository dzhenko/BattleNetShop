namespace BattleNetShop.Data.Xml
{
    using System.Collections.Generic;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public class XmlData : IXmlData
    {
        public IEnumerable<VendorExpense> GetAllVendorExpenses()
        {
            var allVendorExpenses = new List<VendorExpense>();

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
            throw new System.NotImplementedException();
        }
        /*
<?xml version="1.0" encoding="utf-8">
<sales>
  <sale location="location name here">
    <summary date="20-Jul-2013" total-sum="54.75" />
    <summary date="21-Jul-2013" total-sum="40.35" />
    <summary date="22-Jul-2013" total-sum="40.60" />
  </sale>
  <sale vendor="Targovishte Bottling Company Ltd.">
    <summary date="20-Jul-2013" total-sum="150.20" />
    <summary date="21-Jul-2013" total-sum="709.30" />
    <summary date="22-Jul-2013" total-sum="249.40" />
  </sale>
  <sale vendor="Zagorka Corp.">
    <summary date="20-Jul-2013" total-sum="144.80" />
    <summary date="21-Jul-2013" total-sum="341.59" />
    <summary date="22-Jul-2013" total-sum="385.80" />
  </sale>
         */
    }
}
