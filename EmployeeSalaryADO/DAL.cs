using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.Common;

namespace EmployeeSalary
{

    public class DAL
    {
        protected string ConnectionString { get; set; }

        public DAL()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            this.ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("DBConnect").Value;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
        private SqlCommand GetCommand(SqlConnection connection, string procedureName, CommandType commandType)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public SqlDataReader GetDataReader(string procedureName, List<SqlParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            SqlDataReader dr;

            try
            {
                SqlConnection connection = this.GetConnection();
                {
                    SqlCommand cmd = this.GetCommand(connection, procedureName, commandType);
                    if (parameters != null && parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {       
                throw;
            }

            return dr;
        }

    }
}
