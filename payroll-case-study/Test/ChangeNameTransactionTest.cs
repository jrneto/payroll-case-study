using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class ChangeNameTransactionTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestChangeNameTransaction()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob", database);
            cnt.Execute();
            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }
    }
}
