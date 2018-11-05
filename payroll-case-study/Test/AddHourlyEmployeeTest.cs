using Payroll.Domain;
using NUnit.Framework; 

namespace Test
{
    [TestFixture]
    public class AddHourlyEmployeeTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Neto", "Santa Barbara D' Oeste", 50.0, database);
            t.Execute();

            Employee e = database.GetEmployee(empId);
            Assert.AreEqual("Neto", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(50.0, hc.HourlyRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);

        }
    }
}
