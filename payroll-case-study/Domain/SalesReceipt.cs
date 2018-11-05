using System;

namespace Payroll.Domain
{
    public class SalesReceipt
    {
        private readonly DateTime date;
        private readonly double saleAmount;

        public SalesReceipt(DateTime date, double saleAmount)
        {
            this.date = date;
            this.saleAmount = saleAmount;
        }

        public DateTime Date
        {
            get { return date; }
        }
        public double SaleAmount
        {
            get { return saleAmount; }
        }

    }
}