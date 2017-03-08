using InkheartWeb.Common;
using InkheartWeb.Entities.AdminUserEntity;
using InkheartWeb.Infrastructure;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Infrastructure
{
    public class UserLoginService:BaseService<AdminUser>
    {

        public LoginEnum ProcessLogin(string username, string password)
        {

                AdminUser user = Db.Queryable<AdminUser>().FirstOrDefault(i => i.LoginName == username);
                if (user == null)
                {
                    return LoginEnum.NotExist;
                }
                if (!user.Status)
                {
                    return LoginEnum.NotActivated;
                }
                if (!user.Password.Equals(password))
                {
                    return LoginEnum.PwdError;
                }
                else
                {
                    return LoginEnum.Ok;
                }
            
            //存入操作日志表
            //_ll.SaveLog(14, 0, "", loginName);
        }


        public AdminUser GetEntities(string username)
        {

                return Db.Queryable<AdminUser>().Single(i => i.LoginName == username);
            
        }


        public bool RegisterUser(string email, string username, string password)
        {

                AdminUser registerUser = new AdminUser()
                {
                    Email = email,
                    LoginName = username,
                    Password = password,
                    DateTime = DateTime.Now,
                    Status = false
                };
                return Convert.ToBoolean(Db.Insert(registerUser));              
            
        }
    }
}
