using System;

namespace Payroll.Domain
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;

        public TimeCardTransaction(DateTime date, double hours, int empId, IPayrollDatabase database)
            : base (database)
        {
            this.date = date;
            this.hours = hours;
            this.empId = empId;
        }
        public override void Execute()
        {
            Employee e = database.GetEmployee(empId);

            if (e != null)
            {
                HourlyClassification hc = e.Classification as HourlyClassification;

                if (hc != null)
                    hc.AddTimeCard(new TimeCard(date, hours));
                else
                    throw new InvalidOperationException("Tried do add timecard to non-hourly employee");
            }
            else
            {
                throw new InvalidOperationException("No such employee.");
            }
        }
    }
}