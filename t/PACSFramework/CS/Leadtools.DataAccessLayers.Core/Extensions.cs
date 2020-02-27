// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Data.Common;

namespace Leadtools.DataAccessLayers.Core
{
    public static class Extensions
    {
        public static T GetColumnValue<T>(this IDataReader reader, params string[] columnNames)
        {
            bool flag = false;
            T value = default(T);
            IndexOutOfRangeException indexOutOfRangeException = null;
            string[] strArrays = columnNames;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                try
                {
                    int ordinal = reader.GetOrdinal(str);
                    if (!reader.IsDBNull(ordinal))
                    {
                        if (typeof(T).IsEnum)
                        {
                            value = (T)Enum.Parse(typeof(T), reader[ordinal].ToString());
                        }
                        else if (!(typeof(T) == typeof(DateTime?)))
                        {
                            value = (T)reader.GetValue(ordinal);
                        }
                        else
                        {
                            DateTime dateTime = Convert.ToDateTime(reader[ordinal]);
                            value = (T)(object)dateTime;
                        }
                    }
                    flag = true;
                }
                catch (IndexOutOfRangeException indexOutOfRangeException1)
                {
                    indexOutOfRangeException = indexOutOfRangeException1;
                }
            }
            if (!flag)
            {
                string message = string.Format("Column(s) {0} could not be not found.", string.Join(", ", columnNames));

                throw new IndexOutOfRangeException(message, indexOutOfRangeException);
            }

            return value;
        }

        internal static string ToXml(this object value, params Type[] extraTypes)
        {
            XmlSerializer s = new XmlSerializer(value.GetType(), extraTypes);

            using (StringWriter writer = new StringWriter())
            {
                s.Serialize(writer, value);
                return writer.ToString();
            }
        }

        internal static T FromXml<T>(this string value, params Type[] extraTypes)
        {
            XmlSerializer s = new XmlSerializer(typeof(T), extraTypes);

            using (StringReader reader = new StringReader(value))
            {
                object obj = s.Deserialize(reader);
                return (T)obj;
            }
        }

        // Works in C#3/VS2008:
        // Returns a new dictionary of this ... others merged leftward.
        // Keeps the type of 'this', which must be default-instantiable.
        // Example: 
        //   result = map.MergeLeft(other1, other2, ...)
        public static T MergeLeft<T, K, V>(this T me, params IDictionary<K, V>[] others)
            where T : IDictionary<K, V>, new()
        {
            T newMap = new T();
            foreach (IDictionary<K, V> src in
                (new List<IDictionary<K, V>> { me }).Concat(others))
            {
                // ^-- echk. Not quite there type-system.
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }

        public static void AddParameter(this DbCommand command, string name, object value)
        {
            DbParameter parameter = command.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }        
    }
}
