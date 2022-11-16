using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionAPP
{
    internal class DataSource
    {
        private static string connectionString = "Data Source=DESKTOP-A38UJ2R;Initial Catalog=SampleDatabaseForCSharp;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
