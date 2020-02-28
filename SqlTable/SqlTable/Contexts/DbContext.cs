using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTable.Contexts
{
    public class DbContext
    {
        private readonly string connectionString;

        public DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IDataReader> Execute(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    yield return dataReader;
                }
            }
        }

        internal object Execute<T>(string v)
        {
            throw new NotImplementedException();
        }

        public int Insert(string tablename, params SqlParameter[] parameters)
        {
            var sqlparams = GetParameters(parameters);
            string sqlexpression = string.Format(Queries.InsertWithParams,
                 tablename, sqlparams.Column, sqlparams.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameters);

                return (int)command.ExecuteScalar();
            }

        }

        public int Update(string tablename, int id, SqlParameter parameter)
        {
            string sqlexpression = string.Format("UPDATE {0} SET [{1}]=@{1} WHERE Id={2}",
                 tablename, parameter.ParameterName, id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.Add(parameter);
                return command.ExecuteNonQuery();
            }

        }

        public void Delete(string tablename, string column, string value)
        {
            string sqlexpression = string.Format("DELETE FROM {0} WHERE {1}='{2}'",
                 tablename, column, value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);

                command.ExecuteNonQuery();
            }

        }



        private (string Column, string Value) GetParameters(SqlParameter[] parameters)
        {
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();
            foreach (var parameter in parameters)
            {
                columns.Append(parameter.ParameterName).Append(",");
                values.Append("@").Append(parameter.ParameterName).Append(",");
            }

            return (columns.ToString().TrimEnd(','), values.ToString().TrimEnd(','));
        }
    }
}
