using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class ChangeHourlyTransactionTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestChangeHourlyTransactionTest()
        {
            int empId = 3;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 3.2, database);
            t.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 27.52, database);
            cht.Execute();
            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

        }
    }
}
