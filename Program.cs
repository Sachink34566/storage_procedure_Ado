using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_proced
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("1 Add Details ");
                Console.WriteLine("2 Display data");
                Console.WriteLine("3 Delete data");
                Console.WriteLine("4 Update data");
                Console.WriteLine("5 exits");
                Console.WriteLine("enter you4 choice");

                int choice=int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add data");
                        ADD.Add(employees);
                        break;
                    case 2:
                        foreach (Employee e in employees)
                        {
                            e.Display();
                        }
                        Employee.DisplayData();
                        break;
                    case 3:
                        Console.WriteLine("enter id");
                        int id=int.Parse(Console.ReadLine());
                        Employee.Deletedata(id);
                        break;
                    case 4:
                        Console.WriteLine("enter id");
                        int id1=int.Parse(Console.ReadLine());
                        Employee.Upadte(id1);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("enter correct choice");
                        break;
                }
            }
        }
    }
}
