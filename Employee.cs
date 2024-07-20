using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Storage_proced
{
    public class Employee
    {
        public string Name;
        public string Department;
        public decimal Salary;
        public DateTime Date;

        public Employee(string name, string department, decimal salary, DateTime date)
        {
            Name = name;
            Department = department;
            Salary = salary;
            Date = date;
        }
        public void Display()
        {
            Console.WriteLine($"{Name},{Department}, {Salary}, {Date.ToShortDateString()}");
        }

        private static string ConnDB = "Data Source=LAPTOP-QQBSMJER\\SQLEXPRESS ; Initial Catalog=Fullstack; Integrated Security=True";

        public void Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnDB))
                {
                    //string query = "exec save_emps_data @eName,@eDept,@eSalary,@eDate";
                    // multiple query in Store procedure
                    string query = "exec InsertTOUpdate '0',@eName,@eDept,@eSalary,@eDate";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@eName", Name);
                        cmd.Parameters.AddWithValue("@eDept", Department);
                        cmd.Parameters.AddWithValue("@eSalary", Salary);
                        cmd.Parameters.AddWithValue("@eDate", Date);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("successfull insert");
                        }
                        else
                        {
                            Console.WriteLine("failed");
                        }
                        conn.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void DisplayData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnDB))
                {
                    string query = "exec Show_data";
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("=====================================");

                            Console.WriteLine($"{reader.GetInt32(reader.GetOrdinal("Id"))}");
                            Console.WriteLine($"{reader["name"].ToString()}\n" +
                            $"{reader["Dept"].ToString()}\n" +
                            $"{reader.GetDecimal(reader.GetOrdinal("salary"))}\n" +
                            $"{reader.GetDateTime(reader.GetOrdinal("date")).ToShortDateString()}");
                        }
                        conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Deletedata(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnDB))
                {
                    string query = "exec Delete_data @eid";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@eid", id);
                        conn.Open();
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            Console.WriteLine("Delete Successfull");
                        }
                        else
                        {
                            Console.WriteLine("not delete");
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Upadte(int id)
        {
            try
            {
                Console.WriteLine("Enter you name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter you dept");
                string dept = Console.ReadLine();

                Console.WriteLine("enter you salary");
                decimal salary = Decimal.Parse(Console.ReadLine());

                Console.WriteLine("enter you date yyyy-mm-dd");
                DateTime date = DateTime.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(ConnDB))
                {
                    //string query = "exec Update_Data @eid,@eName,@eDept,@eSalary,@eDate ";
                    // multiple query in Store procedureInsertTOUpdate
                    string query = "exec InsertTOUpdate @eid,@eName,@eDept,@eSalary,@eDate ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@eid", id);
                        cmd.Parameters.AddWithValue("@eName", name);
                        cmd.Parameters.AddWithValue("@eDept", dept);
                        cmd.Parameters.AddWithValue("@eSalary", salary);
                        cmd.Parameters.AddWithValue("@eDate", date);
                        conn.Open();
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            Console.WriteLine("update data successfull");
                        }
                        else
                        {
                            Console.WriteLine("update failed");
                        }
                        conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
