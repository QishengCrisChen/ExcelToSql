using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace db
{
    /// <summary>
    /// ����ά�����ݿ������ַ������� Connection ����
    /// </summary>
    class DBHelper
    {
        // ���ݿ������ַ���
        //AIS20141010224300  AIS20140930161237
       // private static string connString = "Data Source=.;Initial Catalog=kis;User ID=sa;Pwd=1989";
        private static string connString = "Data Source=BDSERVER;Initial Catalog=AIS20140930161237;User ID=sa;Pwd=qwert12345!@#$%";

        // ���ݿ����� Connection ����
        public static SqlConnection connection = new SqlConnection(connString);
    }
}
