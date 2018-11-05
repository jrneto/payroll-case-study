using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class ChangeAddressTransactionTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestChangeAddressTransaction()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
            t.Execute();
            ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "Office", database);
            cnt.Execute();
            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Office", e.Address);
        }
    }
}
