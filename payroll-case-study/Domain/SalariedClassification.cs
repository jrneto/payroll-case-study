namespace Payroll.Domain
{
    public class SalariedClassification : PaymentClassification
    {
        public SalariedClassification(double salary)
        {
            this.Salary = salary;
        }
        public double Salary { get; set; }
    }
}