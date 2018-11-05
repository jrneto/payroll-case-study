using System;

namespace Payroll.Domain
{
    public class ServiceChargeTransaction : Transaction
    {
        private readonly int memberId;
        private readonly DateTime time;
        private readonly Double charge;

        public ServiceChargeTransaction(int memberId, DateTime dateTime, Double charge, IPayrollDatabase database)
            : base(database)
        {
            this.memberId = memberId;
            this.time = dateTime;
            this.charge = charge;
        }

        public override void Execute()
        {
            Employee e = database.GetUnionMember(memberId);

            if (e != null)
            {
                UnionAffiliation ua = null;
                if (e.Affiliation is UnionAffiliation)
                    ua = e.Affiliation as UnionAffiliation;

                if (ua != null)
                {
                    ua.AddServiceCharge(new ServiceCharge(time, charge));
                }
                else
                {
                    throw new InvalidOperationException("Tries to add service charge to union. Member without a union affiliation");
                }
            }
            else
            {
                throw new InvalidOperationException("No such union member");
            }
        }
    }
}