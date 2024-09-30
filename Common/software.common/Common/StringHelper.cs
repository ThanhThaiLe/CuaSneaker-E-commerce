using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace software.common.Common
{
    //    private static readonly string[] VietnameseSigns = new string[]

    //{

    //        "aAeEoOuUiIdDyY",

    //        "áàạảãâấầậẩẫăắằặẳẵ",

    //        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

    //        "éèẹẻẽêếềệểễ",

    //        "ÉÈẸẺẼÊẾỀỆỂỄ",

    //        "óòọỏõôốồộổỗơớờợởỡ",

    //        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

    //        "úùụủũưứừựửữ",

    //        "ÚÙỤỦŨƯỨỪỰỬỮ",

    //        "íìịỉĩ",

    //        "ÍÌỊỈĨ",

    //        "đ",

    //        "Đ",

    //        "ýỳỵỷỹ",

    //        "ÝỲỴỶỸ"

    //};
    public static class StringHelper
    {

        //public static string RemoveSign4VietnameseString(string str)

        //{

        //    //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

        //    for (int i = 1; i < VietnameseSigns.Length; i++)

        //    {

        //        for (int j = 0; j < VietnameseSigns[i].Length; j++)

        //            str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

        //    }

        //    return str;

        //}

        public static object GetValuePropertyObject(object value, string path)
        {
            Type currentType = value.GetType();
            foreach (string item in path.Split('.'))
            {
                PropertyInfo propertyInfo = currentType.GetProperty(item);
                value = propertyInfo.GetValue(value, null);
                currentType = propertyInfo.PropertyType;
            }
            return value;
        }
        public static string GetValuePropertyString(object value, string path)
        {
            Type currentType = value.GetType();
            var result = "";
            foreach (string item in path.Split('.'))
            {
                //PropertyInfo propertyInfo = currentType.GetProperty(item);
                //value = propertyInfo.GetValue(value, null);
                //currentType = propertyInfo.PropertyType;
                if (item.Contains("[") | item.Contains("]"))
                {
                    var firstIndex = item.IndexOf('[');
                    var lastIndex = item.IndexOf(']');
                    var handel = item.Substring(0, firstIndex);
                    string posString = item.Substring(firstIndex, lastIndex - firstIndex);
                    int pos = int.Parse(Regex.Replace(posString, @"[^0-9]", ""));
                    List<object> list = new List<object>();
                    try
                    {
                        var objectTemp = StringHelper.GetValuePropertyObject(value, handel);
                        list = ((IEnumerable)objectTemp).Cast<object>().ToList();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    value = list[pos];
                    currentType = value.GetType();
                }
                else
                {
                    PropertyInfo propertyInfo = currentType.GetProperty(item);
                    value = propertyInfo.GetValue(value, null);
                    currentType = propertyInfo.PropertyType;
                }
            }
            if (value == null)
                return "";
            if (value.GetType() == typeof(DateTime?) || value.GetType() == typeof(DateTime))
            {
                if (value != null)
                {
                    var date = (DateTime)value;
                    if (date.Hour == 0 && date.Minute == 0)
                    {
                        result = ((DateTime)value).ToString("dd/MM/yyyy");
                    }
                    else
                    {

                        result = ((DateTime)value).ToString("dd/MM/yyyy HH:ss");
                    }
                }
            }
            else if (value.GetType() == typeof(int?) ||
                value.GetType() == typeof(decimal?) ||
                value.GetType() == typeof(double?) ||
                value.GetType() == typeof(long?) ||
                value.GetType() == typeof(int) ||
                value.GetType() == typeof(decimal) ||
                value.GetType() == typeof(double) ||
                value.GetType() == typeof(long))
            {
                result = string.Format("{0:#,##0.####}", value);
            }
            else
            {
                result = value.ToString();
            }
            return result;
        }
    }
}
