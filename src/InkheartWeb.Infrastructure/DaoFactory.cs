using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Infrastructure
{
    public class  DaoFactory
    {
        public static SqlSugarClient GetSqlSugarClient()
        {
            return SqlSugarCoreDao.GetInstance();
        }

    }
}
