using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_proced
{
    public class ADD
    {
        public static void Add(List<Employee> list)
        {
            Console.WriteLine("Enter you name");
            string name=Console.ReadLine();

            Console.WriteLine("Enter you dept");
            string dept=Console.ReadLine();

            Console.WriteLine("enter you salary");
            decimal salary=Decimal.Parse(Console.ReadLine());

            Console.WriteLine("enter you date yyyy-mm-dd");
            DateTime date=DateTime.Parse(Console.ReadLine());

            Employee emp=new Employee(name,dept,salary,date);
            list.Add(emp);
            emp.Insert();
        }
    }
}
