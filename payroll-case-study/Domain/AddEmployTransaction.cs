using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public abstract class AddEmployTransaction : Transaction
    {
        private readonly int empId;
        private readonly string name;
        private readonly string address;

        public AddEmployTransaction(int empId, string name, string address, IPayrollDatabase database) 
            : base(database)
        {
            this.empId = empId;
            this.name = name;
            this.address = address;
        }

        protected abstract PaymentClassification MakeClassification();

        protected abstract PaymentSchedule MakeSchedule();

        public override void Execute()
        {
            PaymentClassification pc = MakeClassification();
            PaymentSchedule ps = MakeSchedule();
            PaymentMethod pm = new HoldMethod();

            Employee e = new Employee(empId, name, address);
            e.Classification = pc;
            e.Schedule = ps;
            e.Method = pm;
            database.AddEmployee(e);
        }
    }
}
