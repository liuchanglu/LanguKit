using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguUtils
{
    /// <summary>
    /// sql帮助类，越简单越好，够用就行
    /// </summary>
    public class SqlHelper
    {
        private static readonly String conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;//  "Data Source=172.16.0.135\\BIN; Initial Catalog=THIS4;User ID=sa;Password=sql2k!@";

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static DataTable Adapter(String sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = sql;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
