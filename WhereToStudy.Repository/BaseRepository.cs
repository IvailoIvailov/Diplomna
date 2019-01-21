using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace WhereToStudy.Repository
{
    public class BaseRepository
    {
        private string connString = @"Server=.\SQLEXPRESS;database=WhereToStudyDatabase;User Id=sa;Password=Passw0rd;Trusted_Connection=True" ;

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connString);
            }
        }

        public T QueryFirst<T>(string functionName, object parameters)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<T>(functionName, parameters, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<T> QueryMultiple<T>(string functionName, object parameters = null)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<T>(functionName, parameters, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
