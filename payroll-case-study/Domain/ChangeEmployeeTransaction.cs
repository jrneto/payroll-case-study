using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public abstract class ChangeEmployeeTransaction : Transaction
    {
        private readonly int empId;

        public ChangeEmployeeTransaction(int empId, IPayrollDatabase database) : base(database)
        {
            this.empId = empId;
        }

        public override void Execute()
        {
            Employee e = database.GetEmployee(empId);
            if (e != null)
                Change(e);
            else
                throw new InvalidOperationException("No such employee");
        }

        protected abstract void Change(Employee e);
    }
}
