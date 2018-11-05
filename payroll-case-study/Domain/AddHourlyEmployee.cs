using System;

namespace Payroll.Domain
{
    public class AddHourlyEmployee : AddEmployTransaction
    {
        private double hourlyRate;

        public AddHourlyEmployee(int id, string name, string address, double hourlyRate, IPayrollDatabase database)
            : base(id,name,address, database)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}