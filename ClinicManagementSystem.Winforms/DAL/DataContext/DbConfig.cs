using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.DataContext
{
    public static class DbConfig
    {
        public static string ConnectionString =>
            ConfigurationManager
                .ConnectionStrings["ClinicDB"]
                .ConnectionString;
    }
}
