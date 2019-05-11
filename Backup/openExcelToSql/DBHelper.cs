using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace db
{
    /// <summary>
    /// 此类维护数据库连接字符串，和 Connection 对象
    /// </summary>
    class DBHelper
    {
        // 数据库连接字符串
        //AIS20141010224300  AIS20140930161237
       // private static string connString = "Data Source=.;Initial Catalog=kis;User ID=sa;Pwd=1989";
        private static string connString = "Data Source=BDSERVER;Initial Catalog=AIS20140930161237;User ID=sa;Pwd=qwert12345!@#$%";

        // 数据库连接 Connection 对象
        public static SqlConnection connection = new SqlConnection(connString);
    }
}
