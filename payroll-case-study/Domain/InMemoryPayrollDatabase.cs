using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public class InMemoryPayrollDatabase : IPayrollDatabase
    {
        private static Hashtable employees = new Hashtable();
        private static Hashtable unionMembers = new Hashtable();
        
        public void AddEmployee(Employee employee)
        {
            employees[employee.EmpId] = employee;
        }

        public void AddUnionMember(int id, Employee e)
        {
            unionMembers[id] = e;
        }

        public void DeleteEmployee(int id)
        {
            employees.Remove(id);
        }

        public ArrayList GetAllEmployeeIds()
        {
            return new ArrayList(employees.Keys);
        }

        public IList GetAllEmployees()
        {
            return new ArrayList(employees.Values);
        }

        public Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }

        public Employee GetUnionMember(int id)
        {
            return unionMembers[id] as Employee;
        }

        public void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }
    }
}
