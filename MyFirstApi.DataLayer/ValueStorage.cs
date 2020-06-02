using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyFirstApi.Domain.Interfaces;

namespace MyFirstApi.DataLayer
{
    public class ValueStorage: IValueStorage
    {
        private string _connectionString;

        public ValueStorage()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyFirstApiDatabase"].ConnectionString;
        }

        public List<string> GetValues()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var results = connection.Query<string>("[MyFirstApiDB].[Values].usp_Values_GetAll", commandType: CommandType.StoredProcedure);
                return results?.ToList();
            }
        }
    }
}
