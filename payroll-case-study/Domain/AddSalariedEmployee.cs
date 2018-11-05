using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public class AddSalariedEmployee : AddEmployTransaction
    {
        private readonly double salary; 
        public AddSalariedEmployee(int id, string name, string address, double salary, IPayrollDatabase database)
            : base(id,name,address, database)
        {
            this.salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new SalariedClassification(salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
