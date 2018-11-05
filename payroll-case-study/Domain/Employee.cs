namespace Payroll.Domain
{
    public class Employee
    {
        public Employee(int empId, string name, string address)
        {
            this.EmpId = empId;
            this.Name = name;
            this.Address = address;
        }


        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
        public UnionAffiliation Affiliation { get; set; }
    }
}