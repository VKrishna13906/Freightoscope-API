using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using Entities;
using System.Data;
using System.Reflection;

namespace Library
{
    public static class Helper
    {
        public static string HttpValue(string querypara)
        {
            string value = HttpContext.Current.Request.QueryString[querypara];
            return value != null ? value : string.Empty;
        }
        public static ResponseMessage Error(Exception ex)
        {
            return new ResponseMessage(400, $"Error Message: {ex.Message}, StackTrace: {ex.StackTrace}");
        }
        public static bool ValidDataSet(DataSet ds)
        {
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }
        public static List<T> ListConvertDataTable<T>(DataTable dt)
        {

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                catch (Exception ex)
                {

                }
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        object value = dr[column.ColumnName];
                        if (value != DBNull.Value)
                        {
                            //   pro.SetValue(obj, dr[column.ColumnName], null);
                            try
                            {
                                pro.SetValue(obj, Convert.ChangeType(dr[column.ColumnName], pro.PropertyType), null);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
