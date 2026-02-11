using DbManager.Parser;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DbManager
{
    public class Row
    {
        private List<ColumnDefinition> ColumnDefinitions = new List<ColumnDefinition>();
        public List<string> Values { get; set; }

        public Row(List<ColumnDefinition> columnDefinitions, List<string> values)
        {
            //TODO DEADLINE 1.A: Initialize member variables
            ColumnDefinitions = columnDefinitions;
            foreach (var i in values)
            {
                Encode(i);
            }
            Values = values;
            
        }

        public void SetValue(string columnName, string value)
        {
            //TODO DEADLINE 1.A: Given a column name and value, change the value in that column
            int i = 0;
            foreach (var item in ColumnDefinitions)
            {
                if (item.Name == columnName)
                {
                     Values[i]=Encode(value);
                }
                i++;
            }

        }

        public string GetValue(string columnName)
        {
            //TODO DEADLINE 1.A: Given a column name, return the value in that column
            int i = 0;
            foreach (var item in ColumnDefinitions)
            {
                if (item.Name == columnName) {
                    return Decode(Values[i]);
                }
                i++;
            }

            return null;
            
        }

        public bool IsTrue(Condition condition)
        {
            
            string comprobar = condition.LiteralValue;
            string nombreCol= condition.ColumnName;
            ColumnDefinition.DataType type = DataTypeUtils.FromMiniTypeName(comprobar);
            string a = GetValue(nombreCol);

            //TODO DEADLINE 1.A: Given a condition (column name, operator and literal value, return whether it is true or not
            //for this row. Check Condition.IsTrue method

            return condition.IsTrue(a,type);
            
        }

        private const string Delimiter = ":";
        private const string DelimiterEncoded = "[SEPARATOR]";

        private static string Encode(string value)
        {
            //TODO DEADLINE 1.C: Encode the delimiter in value
            if (value == null) {
                return null;
            }

            return value.Replace(Delimiter,DelimiterEncoded);
            
        }

        private static string Decode(string value)
        {
            //TODO DEADLINE 1.C: Decode the value doing the opposite of Encode()

            if (value == null)
            {
                return null;
            }

            return value.Replace(DelimiterEncoded, Delimiter);

        }

        public string AsText()
        {
            //TODO DEADLINE 1.C: Return the row as string with all values separated by the delimiter
            
            int i = 0;
            String row = Values[i];
            foreach (var item in Values)
            {
                if (i > 0)
                {
                    row = row + Delimiter + Encode(Values[i]);
                }
                i++;
            }
            return row;
            
        }

        public static Row Parse(List<ColumnDefinition> columns, string value)
        {
            //TODO DEADLINE 1.C: Parse a rowReturn the row as string with all values separated by the delimiter

            string[] ret=new string[columns.Count];
            
            ret = value.Split(Delimiter);

            List<String> rows = new List<String>();
            for (int i = 0; i < ret.Count(); i++) 
            {
                rows.Add(Decode(ret[i]));
            }
            return new Row(columns,rows);
            
        }
    }
}
