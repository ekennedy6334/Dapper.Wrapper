using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public static class SqlExtensions
    {
        public static string GetTableName(this Type type)
        {
            var tableAttrName = type.GetCustomAttribute<TableAttribute>(false)?.Name ??
                                (type.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic)?.Name;

            string name;
            if (tableAttrName != null)
            {
                name = tableAttrName;
            }
            else
            {
                name = type.Name;
                if (type.IsInterface && name.StartsWith("I"))
                {
                    name = name.Substring(1);
                }
            }

            return name;
        }

        public static bool IsKey(this PropertyInfo propertyInfo)
        {
            var attrs = propertyInfo.GetCustomAttributes(true);
            foreach (var attr in attrs)
            {
                var keyAttribute = attr as KeyAttribute;
                if (keyAttribute != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
