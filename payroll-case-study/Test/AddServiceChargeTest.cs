using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class AddServiceChargeTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }

        [Test]
        public void TestAddServiceCharge()
        {
            int empId = 7;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
            t.Execute();
            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);
            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;

            int memberId = 86; //Maxwell Smart
            database.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2018, 3, 16), 12.95, database);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2018, 3, 16));

            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }

    }
}
