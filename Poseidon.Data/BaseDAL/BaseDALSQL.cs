using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Poseidon.Data
{
    internal class BaseDALSQL
    {
        public void Insert(string tableName, Hashtable recordField)
        {
            SqlDb db = new SqlDb();

            SqlCommand command = new SqlCommand();
            IEnumerator keys = recordField.Keys.GetEnumerator();

            string fields = "";
            string vals = "";
            foreach (var key in recordField.Keys)
            {
                fields += key + ",";
                vals += string.Format("@{0},", key);
                command.Parameters.Add(new SqlParameter("@" + key, recordField[key]));                
            }
            fields = fields.Trim(',');
            vals = vals.Trim(',');

            command.Connection = db.GetConnection();
            command.Connection.Open();
            command.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, fields, vals);            
            command.ExecuteNonQuery();
            command.Connection.Close();
        }


        public int Insert2(string tableName, Hashtable recordField)
        {
            SqlParameter[] param = new SqlParameter[recordField.Count];
            IEnumerator keys = recordField.Keys.GetEnumerator();

            string fields = "";
            string vals = "";
            int i = 0;
            while (keys.MoveNext())
            {
                string field = keys.Current.ToString();
                fields += field + ", ";
                vals += string.Format("@{0}, ", field);

                object val = recordField[field];
                param[i] = new SqlParameter("@" + field, val);
                i++;
            }

            fields = fields.Trim(',');
            vals = vals.Trim(',');



            SqlCommand command = new SqlCommand();
            

            command.ExecuteNonQuery();

            return 0;
        }
    }
}
