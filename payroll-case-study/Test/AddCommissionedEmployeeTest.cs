using Payroll.Domain;
using NUnit.Framework; 

namespace Test
{
    [TestFixture]
    public class AddCommissionedEmployeeTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }
        [Test]
        public void TestAddCommissionedEmployee()
        {
            int empId = 3;

            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Comissionado", "Endereço", 500.00, 10.00, database);
            t.Execute();

            Employee e = database.GetEmployee(empId);
            Assert.AreEqual("Comissionado", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(500.0, cc.BaseRate, .001);
            Assert.AreEqual(10.0, cc.CommissionRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);

        }
    }
}
