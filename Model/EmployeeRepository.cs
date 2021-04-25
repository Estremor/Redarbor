using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using m = Model.Repository;

namespace Model
{
    public class EmployeeRepository : m.Repository, m.IEmployeeRepository
    {
        public EmployeeRepository(SqlConnection context) => _context = context;
        public void Delete(int id)
        {
            using SqlCommand command = CreateCommand("DELETE [dbo].[Employee]  WHERE Id = @id");
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public bool ExistById(int id)
        {
            using (SqlCommand command = CreateCommand(" SELECT * FROM employee E WHERE E.Id = @Id "))
            {
                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                    return true;
            }
            return false;
        }
        public bool ExistByUsername(string username)
        {
            SqlCommand command = CreateCommand(" SELECT * FROM employee E WHERE E.Username = @Username ");
            command.Parameters.AddWithValue("@Username", username);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public Employee Get(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT E.Id, E.CompanyId, E.CreatedOn, E.DeletedOn, E.Email, E.Fax, E.Name, E.Lastlogin, E.Password,");
            query.Append(" E.PortalId ,E.RoleId,E.StatusId, E.Telephone, E.UpdatedOn, E.Username");
            query.AppendLine(" FROM employee E  ");
            query.AppendLine(" where E.Id = @Id");

            using SqlCommand command = CreateCommand(query.ToString());
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CompanyId = Convert.ToInt32(reader["CompanyId"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        DeletedOn = Convert.ToDateTime(reader["DeletedOn"]),
                        Email = reader["Email"]?.ToString(),
                        Fax = reader["Fax"]?.ToString(),
                        Name = reader["Name"]?.ToString(),
                        Lastlogin = Convert.ToDateTime(reader["Lastlogin"]),
                        Password = reader["Password"].ToString(),
                        PortalId = Convert.ToInt32(reader["PortalId"]),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        StatusId = Convert.ToBoolean(reader["StatusId"]),
                        Telephone = reader["Telephone"]?.ToString(),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]),
                        Username = reader["Username"].ToString(),
                    };
                }
            }
            return null;
        }
        public Employee Insert(Employee employee)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" INSERT INTO [dbo].[Employee] ");
            query.Append(" output INSERTED.ID  VALUES ");
            query.Append(" ( @CompanyId, @CreatedOn, @DeletedOn, @Email, @Fax, @Name, @Lastlogin, @Password, @PortalId, @RoleId, @StatusId, @Telephone, @UpdatedOn, @Username)");

            SqlCommand command = CreateCommand(query.ToString());
            command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
            command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@Fax", employee.Fax);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Lastlogin", employee.Lastlogin);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.Parameters.AddWithValue("@PortalId", employee.PortalId);
            command.Parameters.AddWithValue("@RoleId", employee.RoleId);
            command.Parameters.AddWithValue("@StatusId", employee.StatusId);
            command.Parameters.AddWithValue("@Telephone", employee.Telephone);
            command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
            command.Parameters.AddWithValue("@Username", employee.Username);

            employee.Id = Convert.ToInt32(command.ExecuteScalar());
            return employee;
        }
        public IEnumerable<Employee> List()
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT E.Id, E.CompanyId, E.CreatedOn, E.DeletedOn, E.Email, E.Fax, E.Name, E.Lastlogin, E.Password,");
            query.Append(" E.PortalId ,E.RoleId,E.StatusId, E.Telephone, E.UpdatedOn, E.Username");
            query.AppendLine(" FROM employee E  ");

            List<Employee> employees = new List<Employee>();

            SqlCommand command = CreateCommand(query.ToString());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CompanyId = Convert.ToInt32(reader["CompanyId"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        DeletedOn = Convert.ToDateTime(reader["DeletedOn"]),
                        Email = reader["Email"]?.ToString(),
                        Fax = reader["Fax"]?.ToString(),
                        Name = reader["Name"]?.ToString(),
                        Lastlogin = Convert.ToDateTime(reader["Lastlogin"]),
                        Password = reader["Password"].ToString(),
                        PortalId = Convert.ToInt32(reader["PortalId"]),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        StatusId = Convert.ToBoolean(reader["StatusId"]),
                        Telephone = reader["Telephone"]?.ToString(),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]),
                        Username = reader["Username"].ToString(),
                    });
                }
            }
            return employees;
        }
        public void Update(Employee employee)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" UPDATE [dbo].[Employee] SET ");
            query.Append(" [CompanyId] = @CompanyId, ");
            query.Append(" [CreatedOn] = @CreatedOn, ");
            query.Append(" [DeletedOn] = @DeletedOn, ");
            query.Append(" [Email] = @Email, ");
            query.Append(" [Fax] = @Fax,");
            query.Append(" [Name] = @Name, ");
            query.Append(" [Lastlogin] = @Lastlogin, ");
            query.Append(" [Password] = @Password, ");
            query.Append(" [PortalId] = @PortalId, ");
            query.Append(" [RoleId] = @RoleId, ");
            query.Append(" [StatusId] = @StatusId, ");
            query.Append(" [Telephone] = @Telephone, ");
            query.Append(" [UpdatedOn] = @UpdatedOn, ");
            query.Append(" [Username] = @Username ");
            query.Append(" WHERE Id = @Id");

            var command = CreateCommand(query.ToString());

            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
            command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@Fax", employee.Fax);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Lastlogin", employee.Lastlogin);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.Parameters.AddWithValue("@PortalId", employee.PortalId);
            command.Parameters.AddWithValue("@RoleId", employee.RoleId);
            command.Parameters.AddWithValue("@StatusId", employee.StatusId);
            command.Parameters.AddWithValue("@Telephone", employee.Telephone);
            command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
            command.Parameters.AddWithValue("@Username", employee.Username);

            command.ExecuteNonQuery();
        }
    }
}
