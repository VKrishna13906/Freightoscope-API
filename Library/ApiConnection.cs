using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Library
{
    public class ApiConnection
    {
        private static readonly string _con = ConfigurationManager.ConnectionStrings["trainDB"]?.ToString();
        public static string con = _con;
    }
}
