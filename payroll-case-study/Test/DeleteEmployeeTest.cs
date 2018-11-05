using Payroll.Domain;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DeleteEmployeeTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestDeleteEmployee()
        {
            int empId = 4;

            AddCommissionedEmployee t = new AddCommissionedEmployee(  empId, "Bill", "Home", 2500, 3.2, database);
            t.Execute();

            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId, database);
            dt.Execute();

            e = database.GetEmployee(empId);
            Assert.IsNull(e);
        }
    }
}
