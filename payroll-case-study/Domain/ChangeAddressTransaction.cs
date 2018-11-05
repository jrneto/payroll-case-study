namespace Payroll.Domain
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string newAddress; 

        public ChangeAddressTransaction(int empId, string newAddress, IPayrollDatabase database) : base(empId, database)
        {
            this.newAddress = newAddress;   
        }

        protected override void Change(Employee e)
        {
            e.Address = newAddress;
        }
    }
}