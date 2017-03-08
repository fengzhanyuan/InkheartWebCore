using MySqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Infrastructure
{
    public class MySqlSugarCoreDao
    {

        public static string ConnectionString
        {
            get
            {
                string reval = "server=localhost;uid=root;pwd=123456;database=InkHeartWeb_DB";
                return reval;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            return new SqlSugarClient(ConnectionString);
        }

    }
}
