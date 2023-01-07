using System;
using System.Collections.Generic;
using System.Text;

namespace APIMySQL.Data
{
    public class MysqlConfiguration
    {
        public MysqlConfiguration(string connectionString) => ConnectionString = connectionString;
        
        public string ConnectionString { get; set; }
    }
}
