using InkheartWeb.Common;
using InkheartWeb.Entities.AdminUserEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWebCore.Filters
{
    public class LoginCheckFilterController : Controller
    {
        public bool IsCheck { get; set; }
        public AdminUser loginUser { get; set; }
        public LoginCheckFilterController()
        {
            IsCheck = true;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsCheck)
            {
                byte[] bytes;
                filterContext.HttpContext.Session.TryGetValue(ConstCookie.COOKIES_KEY_LOGIN, out bytes);
                if (bytes == null)
                {
                    filterContext.Result = new RedirectResult("/User/Login");
                }
                else
                {
                    this.loginUser = ByteConVertHelper.Bytes2Object<AdminUser>(bytes);
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
