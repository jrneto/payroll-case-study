using System;

namespace Payroll.Domain
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        private readonly string newName;

        public ChangeClassificationTransaction(int empId, IPayrollDatabase database) : base(empId, database)
        {
            
        }
        
        protected override void Change(Employee e)
        {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }

        protected abstract PaymentClassification Classification { get; }
        protected abstract PaymentSchedule Schedule { get; }
    }
}