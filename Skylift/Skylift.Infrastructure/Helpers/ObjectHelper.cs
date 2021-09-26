using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Skylift.Infrastructure.Helpers
{
    /// <summary>
    /// Class ObjectHelper.
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Converts the data table.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns>List of T type</returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }

            return data;
        }

        /// <summary>
        /// Map Data Table To Object.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns>List of object</returns>
        public static List<object> MapDataTableToObject<T>(DataTable dt)
        {
            List<object> data = new List<object>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }

            return data;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="dr">The dr.</param>
        /// <returns>T object type</returns>
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
                        if (dr[column.ColumnName] == DBNull.Value)
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }
    }
}
