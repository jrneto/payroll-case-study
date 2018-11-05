namespace Payroll.Domain
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly double hourlyRate;

        public ChangeHourlyTransaction(int empId, double hourlyRate, IPayrollDatabase database) : base(empId, database)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification Classification
        {
            get { return new HourlyClassification(hourlyRate); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return new WeeklySchedule(); }
        }

       
    }
}