using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace XML_analysis.Repositories
{
    class dbRespository
    {
        public SqlConnection Connection()
        {
            //建立連線
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\OpenData\XML_analysis\App_data\Database1.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(strConn);
            return myConn;
        }

        public void Insert_Data(SqlConnection conn, OpenData item)
        {
            
            conn.Open();
            string sql_insert_code = "INSERT INTO SQLTable(編號,攤名,區域,電話,地址)VALUES(N'"+item.編號+"',N'"+item.攤名+"',N'"+item.區域+"',N'"+item.電話+"',N'"+item.地址+"')" ;
         
            SqlCommand mySqlCmd = new SqlCommand(sql_insert_code, conn);

            mySqlCmd.ExecuteNonQuery();
                  
            conn.Close();
            
        }

    }
}
