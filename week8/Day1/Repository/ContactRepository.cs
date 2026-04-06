using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication7.Models;

namespace ContactApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connStr;

        public ContactRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<ContactInfo> GetAll()
        {
            string sql = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                           FROM ContactInfo c
                           JOIN Company comp ON c.CompanyId = comp.CompanyId
                           LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId";

            return GetConnection().Query<ContactInfo>(sql);
        }

      
        public ContactInfo GetById(int id)
        {
            string sql = "SELECT * FROM ContactInfo WHERE ContactId = @Id";

            return GetConnection().QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
        }


        public void Add(ContactInfo c)
        {
            string sql = @"INSERT INTO ContactInfo
            (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
            VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            GetConnection().Execute(sql, c);
        }

        public void Update(ContactInfo c)
        {
            string sql = @"UPDATE ContactInfo
                   SET FirstName = @FirstName,
                       LastName = @LastName,
                       EmailId = @EmailId,
                       MobileNo = @MobileNo,
                       Designation = @Designation,
                       CompanyId = @CompanyId,
                       DepartmentId = @DepartmentId
                   WHERE ContactId = @ContactId";

            GetConnection().Execute(sql, c);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            GetConnection().Execute(sql, new { Id = id });
        }
        public IEnumerable<Company> GetCompanies()
        {
            string sql = "SELECT * FROM Company";
            return GetConnection().Query<Company>(sql);
        }

        public IEnumerable<Department> GetDepartments()
        {
            string sql = "SELECT * FROM Department";
            return GetConnection().Query<Department>(sql);
        }
    }
}