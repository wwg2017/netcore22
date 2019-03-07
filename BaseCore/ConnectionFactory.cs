using BaseCore;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ABaseCore
{
    public class ConnectionFactory
    {        
        public static MySqlConnection CreateConnection(int connType)
        {
            MySqlConnection conn;
             conn = new MySqlConnection(AppSetting.GetConfig(connType));
            return conn;
        }
    }
}
