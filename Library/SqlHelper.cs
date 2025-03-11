using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SqlHelper
    {
        public static DataSet FillDataSet(SqlParameter[] para, string spName, string Connection, out bool response)
        {
            response = false;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (para != null)
                    {
                        cmd.Parameters.AddRange(para);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        con.Open();
                        da.Fill(ds);
                        con.Close();
                        response = Helper.ValidDataSet(ds);
                        return ds;
                    }
                }
            }
        }
    }
}
