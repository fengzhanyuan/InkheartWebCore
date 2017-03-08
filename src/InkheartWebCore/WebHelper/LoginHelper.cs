using InkheartWeb.Common;
using InkheartWeb.Entities.AdminUserEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWebCore.WebHelper
{
    public class LoginHelper
    {
        /// <summary>
        /// 设置当前登陆用户到当前Session
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="loginedUser"></param>
        public static void SaveLoginedUser(HttpContext ctx, AdminUser loginedUser)
        {
            ctx.Session.SetString(ConstCookie.COOKIES_KEY_LOGIN, JsonHelper.ModelToJson(loginedUser));
        }

        /// <summary>
        /// 得到当前登录的用户
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>当前登陆用户对象，如果没有登录，则为null</returns>
        public static AdminUser GetLoginedUser(HttpContext ctx)
        {
            string jsonUser= ctx.Session.GetString(ConstCookie.COOKIES_KEY_LOGIN);
            return JsonHelper.JsonToModel<AdminUser>(jsonUser);
        }


        /// <summary>
        /// 退出登录时清空
        /// </summary>
        /// <param name="ctx"></param>
        public static void ClearUserSession(HttpContext ctx)
        {
            ctx.Session.Clear();
        }


    }
}
