using System;

namespace Payroll.Domain
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly string newName;

        public ChangeNameTransaction(int empId, string newName, IPayrollDatabase database) : base(empId, database)
        {
            this.newName = newName;
        }
        
        protected override void Change(Employee e)
        {
            e.Name = newName;
        }
    }
}