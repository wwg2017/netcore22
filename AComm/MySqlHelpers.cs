using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AComm
{
    public static class MySqlHelpers
    {
        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="_mySqlConnection"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int BulkLoad(MySqlConnection _mySqlConnection, DataTable table)
        {
            var columns = table.Columns.Cast<DataColumn>().Select(colum => colum.ColumnName).ToList();
            MySqlBulkLoader bulk = new MySqlBulkLoader(_mySqlConnection)
            {
                FieldTerminator = ",",
                FieldQuotationCharacter = '"',
                EscapeCharacter = '"',
                LineTerminator = "\r\n",
                FileName = Directory.GetCurrentDirectory() + "\\UpTemp\\" + table.TableName + ".csv",
                NumberOfLinesToSkip = 0,
                TableName = table.TableName,

            };            
            bulk.Columns.AddRange(columns);
            return bulk.Load();
        }
    }
}
