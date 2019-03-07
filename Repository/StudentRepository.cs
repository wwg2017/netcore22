using ABaseCore;
using AComm;
using AModel;
using IARepository;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace Repository
{
    public class StudentRepository: IStudentRepository
    {
        public int Insert(Student model)
        {
            string sql = @" insert into Student(Age,Name) values (@Age,@Name);";
            using (var conn = ConnectionFactory.CreateConnection((int)Connection.Test数据库))
            {              
                conn.Open();
                var  sqlTransaction = conn.BeginTransaction();

                DataTable dt = new DataTable
                {
                    TableName = "student"
                };
                dt.Columns.Add("name");
                dt.Columns.Add("age");

                for (int i = 1; i <= 50000; i++)
                {
                    dt.Rows.Add(new Object[] { "wwg" + i, i });
                }
                CSVEx.ToCsv(dt);
                var sw = new Stopwatch();
                sw.Start();
                MySqlHelpers.BulkLoad(conn, dt);
                sw.Stop();
                var p = sw.ElapsedMilliseconds;
                sqlTransaction.Commit();
                return 1;
                // return DbContext.Execute(conn, sql, model);
            }
        }
    }
}
