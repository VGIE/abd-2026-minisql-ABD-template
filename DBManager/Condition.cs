using DbManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DbManager
{
    public class Condition
    {
        public string ColumnName { get; private set; }
        public string Operator { get; private set; }
        public string LiteralValue { get; private set; }

        public Condition(string column, string op, string literalValue)
        {
            //TODO DEADLINE 1A: Initialize member variables
            ColumnName = column;
            Operator = op;
            LiteralValue = literalValue;

        }


        public bool IsTrue(string value, ColumnDefinition.DataType type)
        {

            //TODO DEADLINE 1A: return true if the condition is true for this value
            //Depending on the type of the column, the comparison should be different:
            //"ab" < "cd
            //"9" > "10"
            //9 < 10
            //Convert first the strings to the appropriate type and
            //then compare (depending on the operator of the condition)
            bool esIg = false;
            bool esMa = false;
            bool esMe = false;

            if (value == null) { value = ""; }
            if (LiteralValue == null) { LiteralValue = ""; }

            switch (type)
            {
                case ColumnDefinition.DataType.String:
                    int cmp = string.Compare(value, LiteralValue);
                    esIg = (cmp == 0);
                    esMa = (cmp > 0);
                    esMe = (cmp < 0);
                    break;
                case ColumnDefinition.DataType.Int:
                    int vInt = int.Parse(value);
                    int literalInt = int.Parse(LiteralValue);
                    if (vInt == literalInt) { esIg = true; }
                    if (vInt > literalInt) { esMa = true; }
                    if (vInt < literalInt) { esMe = true; }
                    break;
                case ColumnDefinition.DataType.Double:
                    string vLimpio = value.Replace(".", ",");
                    string lLimpio = LiteralValue.Replace(".", ",");

                    double vDouble = double.Parse(vLimpio);
                    double literalDouble = double.Parse(lLimpio);

                    if (vDouble == literalDouble) { esIg = true; }
                    if (vDouble > literalDouble) { esMa = true; }
                    if (vDouble < literalDouble) { esMe = true; }
                    break;
            }
            if (Operator == "=") { return esIg; }
            if (Operator == ">") { return esMa; }
            if (Operator == "<") { return esMe; }

            return false;

        }
    }
}