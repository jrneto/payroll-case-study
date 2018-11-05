using System;

namespace Payroll.Domain
{
    public class ServiceCharge
    {
        private DateTime time;
        private double amount;

        public ServiceCharge(DateTime time, double amount)
        {
            this.time = time;
            this.amount = amount;
        }

        public double Amount
        {
            get { return amount; }
        }

        public DateTime Time
        {
            get { return time; }
        }
    }
}