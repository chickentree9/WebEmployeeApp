using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using System.Data.Common;
using System.Data;

namespace WebEmployeeApp.Pages
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=tcp:trackerzq.database.windows.net,1433;Initial Catalog=tracker;Persist Security Info=False;User ID=uoeno;Password=Unyuns_89;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        // Execute a SQL command that deletes an employee 
        public static int DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employees WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", id);
            return ExecuteNonQuery(query, parameters);
        }

        //Execute a SQL command that adds an employee

        public static int AddEmployee(string firstName, string lastName, string email, string phone, string department, string position, string salary)
        {
            string query = "INSERT INTO Employees (FirstName, LastName, Email, Phone, Department, Position, Salary) VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @Position, @Salary)";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@FirstName", firstName);
            parameters[1] = new SqlParameter("@LastName", lastName);
            parameters[2] = new SqlParameter("@Email", email);
            parameters[3] = new SqlParameter("@Phone", phone);
            return ExecuteNonQuery(query, parameters);
        }

        // Execute a SQL command that updates an employee
        public static int UpdateEmployee(int id, string firstName, string lastName, string email, string phone, string department, string position, string salary)
        {
            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Department = @Department, Position = @Position, Salary = @Salary WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("@FirstName", firstName);
            parameters[1] = new SqlParameter("@LastName", lastName);
            parameters[2] = new SqlParameter("@Email", email);
            parameters[3] = new SqlParameter("@Phone", phone);
            return ExecuteNonQuery(query, parameters);
        }


        // Execute a SQL command to add a new employee with the provided details
        public bool AddEmployee(string employeeFirstName, string employeeLastName, string employeeEmail, string employeePhone, string emergencyContact, decimal hourlyRate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (FirstName, LastName, Email, Phone, EmergencyContact, HourlyRate, RoleID) " +
                               "VALUES (@FirstName, @LastName, @Email, @Phone, @EmergencyContact, @HourlyRate, @RoleID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employeeFirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employeeLastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employeeEmail;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = employeePhone;

                    command.Parameters.Add("@EmergencyContact", SqlDbType.NVarChar).Value = emergencyContact;

                    command.Parameters.Add("HourlyRate", SqlDbType.Decimal).Value = hourlyRate;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }


        // Execute a SQL command to delete an employee based on the provided credentials
        public bool DeleteEmployee(string employeeFirstName, string employeeLastName, string employeeEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE FirstName = @FirstName AND LastName = @LastName AND Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employeeFirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employeeLastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employeeEmail;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }




        // Execute a SQL command that returns a list of users based on the query and parameters
        private List<Users> ReadUsers(string query, SqlParameter[] parameters)
        {
            List<Users> users = new List<Users>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                // Populate the Users object based on the data reader
                               // First and last name

                                Id = Convert.ToInt32(reader["Id"]), // Id
                                FirstName = Convert.ChangeType(reader["Name"], typeof(string)),

                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }
   

private static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        internal List<Users> ReadUsers()
        {
            throw new NotImplementedException();
        }


        //Logins section from tracker database
        public class Logins
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }


    }
}
