using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using db;
using System.Data.SqlClient;

namespace openExcelToSql
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonopen_Click(object sender, EventArgs e)
        {
            if (openFileDialogSource.ShowDialog() == DialogResult.OK)
            {
                ctlPath.Text = openFileDialogSource.FileName;
                ExceltoDataSet(ctlPath.Text);

                
                
           }

        }
        DataTable dTable;//全局变量
     
        //     string tableName = schemaTable.Rows[0][2].ToString().Trim();

        //打开方法 
        public DataTable ExceltoDataSet(string path)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + @path + ";" + "Extended Properties=Excel 12.0;";
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            
            DataSet ds = null;
            System.Data.DataTable dt=null;
          
            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                string tableName = schemaTable.Rows[0][2].ToString().Trim();
                strExcel = "select * from [" + tableName + "]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                //DataTable dt = new DataTable();
                ds = new DataSet();
                myCommand.Fill(ds);
                 dt = ds.Tables[0];
                
                if (dt.Columns.Count > 1 && dt.Rows.Count >= 1)
                {
                    gridSource.DataSource = dt;
                    gridSource.RowHeadersWidth = 18;
                    gridSource.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    gridSource.AllowUserToResizeRows = false;//行大小不能调整
                    tb.Text = "Total: " + (gridSource.RowCount-1).ToString() + " data";
                    ;
                }
                else
                {
                    MessageBox.Show(tableName + " No data to import!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Import Excel failure!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dTable = dt;
            return dt;
            

        }
        public void gx()
        {

          
            DBHelper.connection.Open();
            string strsql = " EXEC  proc_gx";
            SqlCommand cmd = new SqlCommand(strsql, DBHelper.connection);
            cmd.CommandTimeout = 180;
            cmd.ExecuteNonQuery();
            DBHelper.connection.Close();
            MessageBox.Show(" Import Sucessful！", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
       
         //SqlCommand command = new SqlCommand(sql, DBHelper.connection);  // 创建command对象
           //         DBHelper.connection.Open();  // 打开数据库连接

             //       int result = command.ExecuteNonQuery();  // 执行命令

        //   string sql = string.Format("DELETE FROM Student WHERE StudentID={0}",(int)lvStudent.SelectedItems[0].Tag);

        private void btnsx_Click(object sender, EventArgs e)
        {
            ImportTableToDB(dTable);
            //gx();
           
        }
        public bool ImportTableToDB(DataTable dtImp)
        {
            delete();
            int i = 1;
            try
            {
                foreach (DataRow datarow in dTable.Rows)
                {

                    DBHelper.connection.Open();
                  
             
                    string sql = "insert into test(日期,车号,加气量,职员,含税单价,含税金额,单价,金额,税额,备注,供应商,ID) values(@日期,@车号,@加气量,@职员,@含税单价,@含税金额,@单价,@金额,@税额,@备注,@供应商,@ID)";
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.connection);
                    cmd.Parameters.AddWithValue("@日期", datarow["日期"].ToString());
                    cmd.Parameters.AddWithValue("@车号", datarow["车号"].ToString());
                    cmd.Parameters.AddWithValue("@加气量", datarow["加气量"].ToString());
                    cmd.Parameters.AddWithValue("@职员", datarow["职员"].ToString());
                    cmd.Parameters.AddWithValue("@含税单价", datarow["含税单价"].ToString());
                    cmd.Parameters.AddWithValue("@含税金额", datarow["含税金额"].ToString());
                    cmd.Parameters.AddWithValue("@单价", datarow["单价"].ToString());
                    cmd.Parameters.AddWithValue("@金额", datarow["金额"].ToString());
                    cmd.Parameters.AddWithValue("@税额", datarow["税额"].ToString());
                    cmd.Parameters.AddWithValue("@备注", datarow["备注"].ToString());
                    cmd.Parameters.AddWithValue("@供应商", datarow["供应商"].ToString());
                    cmd.Parameters.AddWithValue("@ID", i++);
                    
                    cmd.ExecuteNonQuery();
                    DBHelper.connection.Close();
                }

               // MessageBox.Show( " 导入成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        private void btnsr_Click(object sender, EventArgs e)
        {
            Tosql(dTable);
           // srgx();
        }
        public void srgx()
        {


            DBHelper.connection.Open();
            string strsql = " EXEC  proc_srgx";
            SqlCommand cmd = new SqlCommand(strsql, DBHelper.connection);
            cmd.CommandTimeout = 180;
            cmd.ExecuteNonQuery();
            DBHelper.connection.Close();
            MessageBox.Show(" 导入成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void deletesr()
        {


            DBHelper.connection.Open();
            string strsql = "DECLARE @test int   select @test=count(*) from test_1 if @test>0  delete test_1";
            SqlCommand cmd = new SqlCommand(strsql, DBHelper.connection);
            cmd.ExecuteNonQuery();
            DBHelper.connection.Close();
    
        }
        public void delete()
        {
            //如果test里有数据删除deletesr同理

            DBHelper.connection.Open();
            string strsql = "DECLARE @test int   select @test=count(*) from test if @test>0  delete test";
            SqlCommand cmd = new SqlCommand(strsql, DBHelper.connection);
            cmd.ExecuteNonQuery();
            DBHelper.connection.Close();

        }
        public bool Tosql(DataTable dtImp)
        {
            deletesr();
            int i = 1;
            try
            {
                foreach (DataRow datarow in dTable.Rows)
                {

                    
                    DBHelper.connection.Open();
                    string sql = "insert into test_1(客户户名,日期,车号,车次,原发数,实收数,单价,扣费,金额,付回货,车队收入,供应商,亏吨,备注,id) values(@客户户名,@日期,@车号,@车次,@原发数,@实收数,@单价,@扣费,@金额,@付回货,@车队收入,@供应商,@亏吨,@备注,@id)";
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.connection);
                    cmd.Parameters.AddWithValue("@客户户名", datarow["客户户名"].ToString());
                    cmd.Parameters.AddWithValue("@日期", datarow["日期"].ToString());
                    cmd.Parameters.AddWithValue("@车号", datarow["车号"].ToString());
                    cmd.Parameters.AddWithValue("@车次", datarow["车次"].ToString());
                    cmd.Parameters.AddWithValue("@原发数", datarow["原发数"].ToString());
                    cmd.Parameters.AddWithValue("@实收数", datarow["实收数"].ToString());
                    cmd.Parameters.AddWithValue("@单价", datarow["单价"].ToString());
                    cmd.Parameters.AddWithValue("@扣费", datarow["扣费"].ToString());
                    cmd.Parameters.AddWithValue("@金额", datarow["金额"].ToString());
                    cmd.Parameters.AddWithValue("@亏吨", datarow["亏吨"].ToString());
                    cmd.Parameters.AddWithValue("@付回货", datarow["付回货"].ToString());
                    cmd.Parameters.AddWithValue("@车队收入", datarow["车队收入"].ToString());
                    cmd.Parameters.AddWithValue("@备注", datarow["备注"].ToString());
                    cmd.Parameters.AddWithValue("@供应商", datarow["供应商"].ToString());
                    cmd.Parameters.AddWithValue("@ID", i++);
                    //MessageBox.Show(sql, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmd.ExecuteNonQuery();
                    DBHelper.connection.Close();
                }

                //MessageBox.Show(" 导入成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;

            }
            catch
            {
                return false;
            }
        }

       }

       

    }
