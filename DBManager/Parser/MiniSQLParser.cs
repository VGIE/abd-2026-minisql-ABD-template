using DbManager.Parser;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DbManager
{
    public class MiniSQLParser
    {
        public static MiniSqlQuery Parse(string miniSQLQuery)
        {
            //TODO DEADLINE 2
            //SELECT columnas FROM tabla patrón
            const string selectPattern =@"^SELECT\s+([a-zA-Z0-9,\s\*]+)\s+FROM\s+([a-zA-Z0-9]+)$" ;
           
           //INSERT INTO tabla VALUES columnas patrón
            const string insertPattern = @"^INSERT\s+INTO\s+([a-zA-Z0-9]+)\s+VALUES\s+\(([a-zA-Z0-9, ]+)\)$";

           //DROP TABLE tabla patrón
            const string dropTablePattern = @"^DROP\s+TABLE\s+([a-zA-Z0-9]+)$";
            
            //Note: The parsing of CREATE TABLE should accept empty columns "()"
            //And then, an execution error should be given if a CreateTable without columns is executed
            const string createTablePattern = @"^CREATE\s+TABLE\s+([a-zA-Z0-9]+)\s+\(([a-zA-Z0-9,\s]*)\)$";
            
            const string updateTablePattern = @"^UPDATE\s+([a-zA-Z0-9]+)\s+SET\s+([a-zA-Z0-9\s\=\,]+)\s+WHERE\s+(.+)$";

            const string deletePattern = @"^DELETE\s+FROM\s+([a-zA-Z0-9]+)\s+WHERE\s+(.+)$";

            //TODO DEADLINE 4
            const string createSecurityProfilePattern = @"^CREATE\s+SECURITY\s+PROFILE\s+([a-zA-Z0-9]+)$";
            
            const string dropSecurityProfilePattern = @"^DROP\s+SECURITY\s+PROFILE\s+([a-zA-Z0-9]+)$";
            
            //Captura la tabla, el privilegio y el perfil  
            const string grantPattern = @"^GRANT\s+(SELECT|INSERT|UPDATE|DELETE)\s+ON\s+([a-zA-Z0-9]+)\s+TO\s+([a-zA-Z0-9]+)$";

            const string revokePattern = @"^REVOKE\s+(SELECT|INSERT|UPDATE|DELETE)\s+ON\s+([a-zA-Z0-9]+)\s+TO\s+([a-zA-Z0-9]+)$";
            
            //Patrón para obtener ADD USER (usuario)(contraseña)(perfil) con espacio entre add y user y los paréntesis de luego
            const string addUserPattern = @"^ADD\s+USER\s+\(([a-zA-Z0-9]+),\s*([a-zA-Z0-9]+),\s*([a-zA-Z0-9]+)\)$";
    
            const string deleteUserPattern = @"^DELETE\s+USER\s+([a-zA-Z0-9]+)$";

            //TODO DEADLINE 2
            //Parse query using the regular expressions above one by one. If there is a match, create an instance of the query with the parsed parameters
            //For example, if the query is a "SELECT ...", there should be a match with selectPattern. We would create and return an instance of Select
            //initialized with the table name, the columns, and (possibly) an instance of Condition.
            //If there is no match, it means there is a syntax error. We will return null.
            

            //TODO DEADLINE 4
            //Do the same for the security queries (CREATE SECURITY PROFILE, ...)
            
            return null;
           
        }

        static List<string> CommaSeparatedNames(string text)
        {
            string[] textParts = text.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
            List<string> commaSeparator = new List<string>();
            for(int i=0; i < textParts.Length; i++)
            {
                commaSeparator.Add(textParts[i]);
            }
            return commaSeparator;
        }
        
    }
}
