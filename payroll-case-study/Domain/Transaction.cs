namespace Payroll.Domain
{
    public abstract class Transaction
    {
        protected readonly IPayrollDatabase database;
        public abstract void Execute();

        public Transaction (IPayrollDatabase database)
        {
            this.database = database;
        }
       
    }
}