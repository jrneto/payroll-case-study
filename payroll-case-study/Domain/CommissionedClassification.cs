using System;
using System.Collections;

namespace Payroll.Domain
{
    public class CommissionedClassification : PaymentClassification
    {
        private readonly double baseRate;
        private readonly double commissionRate;

        private Hashtable salesReceipts = new Hashtable();
        
        public double BaseRate
        {
            get { return baseRate; }
        }

        public double CommissionRate
        {
            get { return commissionRate; }
        }

        public CommissionedClassification(double baseRate, double commissionRate)
        {
            this.baseRate = baseRate;
            this.commissionRate = commissionRate;
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            salesReceipts[salesReceipt.Date] = salesReceipt;
        }

        public SalesReceipt GetSalesReceipt(DateTime time)
        {
            return salesReceipts[time] as SalesReceipt;
        }
    }
}