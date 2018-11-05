using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class SalesReceiptTransactionTest
    {
        private IPayrollDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new InMemoryPayrollDatabase();
        }
        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 6;
            DateTime saleDate = new DateTime(2017, 09, 07);
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Commissioned", "Sertãozinho", 1000, 10, database);
            t.Execute();

            Employee e = database.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            SalesReceiptTransaction srt = new SalesReceiptTransaction(empId, saleDate, 100.00, database);
            srt.Execute();

            CommissionedClassification cc = pc as CommissionedClassification;
            SalesReceipt sr = cc.GetSalesReceipt(saleDate);

            Assert.IsNotNull(sr);
            Assert.AreEqual(100.00, sr.SaleAmount, .001);


        }
    }
}
