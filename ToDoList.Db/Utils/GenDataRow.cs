using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Db.Utils
{

    public class GenDataRow
    {
        protected Dictionary<string, object> fieldsValues = new Dictionary<string, object>();
        private const string _logPrefix = "GenDataRow - ";

        public T TryGet<T>(string field, T default_value = default(T), string errorMsg = null)
        {
            var value = this[field];
            if (value == null)
                return default_value;

            try
            {
                return (T)value;
            }
            catch (Exception ex)
            {
                try
                {
                    var result = (T)Convert.ChangeType(value, typeof(T));
                    return result;
                }
                catch (Exception)
                {
                    return default_value;
                }
            }
        }

        [Obsolete("use TryGet instead")]
        public object this[string field]
        {
            get
            {
                object value;
                if (!fieldsValues.TryGetValue(field, out value))
                {
                    //QA asked to remark because this log is overflowing the logs...use in case of new integration with new parameters
                    //LogUtils.Info($"field {field} not found in prodecure result"); 
                    return null;
                }
                return value;
            }
        }

        public void InitializeByReaderValues(IDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var field = reader.GetName(i);
                if (!fieldsValues.ContainsKey(field))
                {
                    object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    fieldsValues.Add(field, value);
                }
            }
        }

        //public string AsString(bool serializeNullValues = true)
        //{
        //    return JsonUtils.Serialize(fieldsValues, serializeNullValues, true, true);
        //}

        /// <summary>
        /// Removed empty entries and selected keys and parses to JSON
        /// </summary>
        /// <param name="removeKeys"></param>
        /// <returns></returns>
        //public string AsCleanString(params string[] removeKeys)
        //{
        //    var cleanFields = new Dictionary<string, object>();
        //    foreach (var field in fieldsValues)
        //    {
        //        if (removeKeys != null && removeKeys.Contains(field.Key))
        //            continue;
        //        var val = field.Value?.ToString();
        //        if (!string.IsNullOrWhiteSpace(val) && val != "0" && val != "-1" && val.ToLower() != "false")
        //            cleanFields[field.Key] = val;
        //    }
        //    return JsonUtils.Serialize(cleanFields, false, true, true);
        //}
    }
}
