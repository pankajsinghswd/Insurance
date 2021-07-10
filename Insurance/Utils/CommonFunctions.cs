using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Insurance.Utils
{
    public class CommonFunctions
    {
        private CommonFunctions() { }
        public static string ConvertDataTabletoJSON(System.Data.DataTable dtable)
        {
            System.Data.DataTable dt = dtable;
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
        /// <summary>
        /// Converts the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }
            return data;
        }

        /// <summary>
        /// Converts the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static T ConvertDataTableToModel<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }
            return data.FirstOrDefault();
        }
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The dr.</param>
        /// <returns></returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                if (dr != null)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        PropertyInfo propertyInfos = obj.GetType().GetProperty(pro.Name);
                        if (pro.Name.ToLower() == column.ColumnName.ToLower())
                        {
                            var value = (dr[pro.Name] == DBNull.Value) ? null : dr[pro.Name]; //if database field is nullable
                                                                                              //  Convert.ToInt64(dr.Field<double>("ID"));
                            pro.SetValue(obj, value, null);
                        }
                        else
                            continue;
                    }
                }
            }
            return obj;
        }
        public static string GetSelectedDate(string date)
        {
            string []formatDate = date.Split('-');
            return formatDate[2] + "-" + formatDate[1] + "-" + formatDate[0];
        }
    }
}