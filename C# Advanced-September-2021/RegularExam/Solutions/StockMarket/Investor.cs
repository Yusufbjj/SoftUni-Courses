using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }


        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count
        {
            get => portfolio.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000)
            {
                if (MoneyToInvest >= stock.PricePerShare)
                {
                    MoneyToInvest -= stock.PricePerShare;
                    portfolio.Add(stock);
                }
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(stock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);
            return stock;
        }

        public Stock FindBiggestCompany()
        {
            if (portfolio.Count > 0)
            {
                return portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
            }

            return null;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
