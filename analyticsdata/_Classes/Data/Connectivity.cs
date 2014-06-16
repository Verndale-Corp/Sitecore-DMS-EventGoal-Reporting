using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

using analyticsdata._DBML;

namespace analyticsdata.Data
{
    /// <summary>
    /// The Connectivity class contains properties and methods for obtaining the connection string to the custom database 
    /// and creating a connection to it;
    /// </summary>
    public class Connectivity
    {
        private static string _connectionString = "";
        public static SqlConnection ConnectionString
        {
            get
            {
                if (_connectionString.Length == 0)
                {
                    _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["analytics"].ConnectionString;
                }
                return new SqlConnection(_connectionString);
            }
        }       

        public static analyticsDataContext GetMainDataContext()
        {
            var context = new analyticsDataContext(ConnectionString);
            return context;
        }       
    }
}