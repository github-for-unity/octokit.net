using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Octokit
{
    public static class EnumerableExtensions35
    {
        public static String Join<T>(this IEnumerable<T> values, String separator)
        {
#if !NET_35
            return String.Join(separator, values);
#else
            if (values == null)
                throw new ArgumentNullException("values");

            if (separator == null)
                separator = String.Empty;

            using (var en = values.GetEnumerator())
            {
                if (!en.MoveNext())
                    return String.Empty;

                StringBuilder result = new StringBuilder();
                if (en.Current != null)
                {
                    result.Append(en.Current);
                }

                while (en.MoveNext())
                {
                    result.Append(separator);
                    if (en.Current != null)
                    {
                        result.Append(en.Current);
                    }
                }
                return result.ToString();
#endif
            }
        }

        const BindingFlags everything = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type)
        {
            CheckAndThrow(type);
            return type.GetFields(everything);
        }

        public static object GetValue(this PropertyInfo prop, object instance)
        {
            return prop.GetValue(instance, null);
        }

        public static bool IsDisposed(this CancellationTokenSource cts)
        {
            return cts.GetPropertyValue<bool>("IsDisposed");
        }

        public static void SetValue(this PropertyInfo prop, object instance, object value)
        {
            prop.SetValue(instance, value, null);
        }

        public static void SetValue(this FieldInfo field, object instance, object value)
        {
            field.SetValue(instance, value, BindingFlags.Default, Type.DefaultBinder, null);
        }

        public static T GetPropertyValue<T>(this object obj, string property)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (property == null) throw new ArgumentNullException("property");
            var type = obj.GetType();
            var prop = type.GetProperty(property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (prop == null) throw new InvalidOperationException(String.Format("Property {0} not found in type {1}", property, type));
            return (T)prop.GetValue(obj, null);
        }

        static void CheckAndThrow(Type t)
        {
            if (t == null) throw new ArgumentNullException("type");
        }
    }


    public static class CustomAttributeExtensions
    {
        #region APIs that return a single attribute
        public static Attribute GetCustomAttribute(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }
        public static Attribute GetCustomAttribute(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        public static T GetCustomAttribute<T>(this Assembly element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }
        public static T GetCustomAttribute<T>(this Module element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }
        public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }
        public static T GetCustomAttribute<T>(this ParameterInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T), inherit);
        }
        public static T GetCustomAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T), inherit);
        }
        #endregion

        #region APIs that return all attributes
        public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element)
        {
            return Attribute.GetCustomAttributes(element);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this Module element)
        {
            return Attribute.GetCustomAttributes(element);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }
        #endregion

        #region APIs that return all attributes of a particular type
        public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this Assembly element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this Module element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }

        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T), inherit);
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element, bool inherit) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T), inherit);
        }
        #endregion

        #region IsDefined
        public static bool IsDefined(this Assembly element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }
        public static bool IsDefined(this Module element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }
        public static bool IsDefined(this MemberInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }
        public static bool IsDefined(this ParameterInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        public static bool IsDefined(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }
        public static bool IsDefined(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }
        #endregion
    }

}

namespace GitHub.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null)
            {
                return true;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
