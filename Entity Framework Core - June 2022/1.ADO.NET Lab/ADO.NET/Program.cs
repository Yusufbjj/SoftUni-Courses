using System;
using System.Data.SqlClient;
using ADO.NET;

namespace ADO.NET_LiveDemo_June2022
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //First of all install correct DataProvider for ADO.NET

            //DataProvider for SQL Server -> SqlClient

            //If Authentication is needed

            //SqlCredential sqlCredential = new SqlCredential(username, password);

            //Created connection

            using SqlConnection sqlConnection =
                new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            //Here we have opened connection

            //Then we need to create a command

            //If we use transaction -> On add/update/delete use Transaction

            //SqlTransaction transaction = sqlConnection.BeginTransaction();

            string employeeCntQuery = @"SELECT COUNT(*) 
                                            AS [EmployeeCount] 
                                          FROM [Employees]";

            SqlCommand employeeCntCmd = new SqlCommand(employeeCntQuery, sqlConnection);

            int employeeCount = (int)employeeCntCmd.ExecuteScalar();

            Console.WriteLine($"Employees available: {employeeCount}. Choose:");

            //Invalid command

            //SqlCommand invalidCntCmd = new SqlCommand(employeeCntQuery);

            //invalidCntCmd.ExecuteScalar();


            string jobTitleEnt = Console.ReadLine();

            //If we are here, the above query has ended and the connection is free

            //Interpolated Strings -> SQL Injection Possible

            //Parameters -> SQL Injection Impossible

            string employeeInfoQuery = @"SELECT [FirstName],
                                                [LastName],
                                                [JobTitle]
                                           FROM [Employees]
                                          WHERE [JobTitle] = @jobTitle";

            SqlCommand employeeInfoCmd =
                new SqlCommand(employeeInfoQuery, sqlConnection);

            employeeInfoCmd.Parameters.AddWithValue("@jobTitle", jobTitleEnt);

            using SqlDataReader employeeInfoReader =
                employeeInfoCmd.ExecuteReader();

            //Read -> True (another rows)

            //Read -> False (last row)

            //While there are rows -> Go on the next row

            int rowNum = 1;

            while (employeeInfoReader.Read())
            {
                string firstName = (string)employeeInfoReader["FirstName"];
                string lastName = (string)employeeInfoReader["LastName"];
                string jobTitle = (string)employeeInfoReader["JobTitle"];

                Console.WriteLine($"#{rowNum++}. {firstName} {lastName} - {jobTitle}");
            }
            employeeInfoReader.Close();

            sqlConnection.Close();

            Console.WriteLine("----------------------------------------------");

            //Just for debuggion

            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue...");
        }
    }
}
