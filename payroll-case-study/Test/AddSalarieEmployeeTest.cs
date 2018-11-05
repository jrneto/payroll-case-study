using Payroll.Domain;
using NUnit.Framework;
using System;
namespace Test
{
    [TestFixture]
    public class AddSalarieEmployeeTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }
        
        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00, database);
            t.Execute();

            Employee e = database.GetEmployee(empId);

            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;

            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;

            Assert.AreEqual(1000.00, sc.Salary, .001);

            PaymentSchedule ps = e.Schedule;

            Assert.IsTrue(ps is MonthlySchedule);

            PaymentMethod pm = e.Method;

            Assert.IsTrue(pm is HoldMethod);
        }
    }


}
