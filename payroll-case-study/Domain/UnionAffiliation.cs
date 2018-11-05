using System;
using System.Collections;

namespace Payroll.Domain
{
    public class UnionAffiliation
    {
        private Hashtable serviceCharges = new Hashtable();
        public UnionAffiliation()
        {
        }

        public ServiceCharge GetServiceCharge(DateTime dateTime)
        {
            return serviceCharges[dateTime] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            serviceCharges[serviceCharge.Time] = serviceCharge;
        }
    }
}