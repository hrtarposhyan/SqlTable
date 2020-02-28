using SqlTable.Contexts;
using System.Data.SqlClient;

namespace SqlTable
{
    class Program
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MicSchool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        static void Main(string[] args)
        {
            var context = new DbContext(ConnectionString);
            SqlParameter par1 = new SqlParameter("Name", "Mashtoci");
            context.Update("University", 2, par1);

        }
    }
}
