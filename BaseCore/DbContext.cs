using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ABaseCore
{
    public class DbContext
    {
        public static int Execute(IDbConnection _conn, string sql, object param = null)
        {
            using (IDbConnection conn = _conn)
            {
                return conn.Execute(sql, param, commandTimeout: 600);
            }
        }
    }
}
