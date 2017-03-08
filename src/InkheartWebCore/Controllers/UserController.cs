using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InkheartWeb.Common;
using InkheartWeb.Infrastructure;
using InkheartWebCore.WebHelper;
using InkheartWebCore.Filters;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InkheartWebCore.Controllers
{

    public class UserController : LoginCheckFilterController
    {
       
        private UserLoginService _userService;
        public  UserController()
        {
            _userService = new UserLoginService();
            this.IsCheck = false;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登陆
        /// </summary> 
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login(string username,string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return "Please Input LoginName or Password!";
            }
            LoginEnum result = _userService.ProcessLogin(username, password);
            switch (result)
            {
                case LoginEnum.NotExist:
                    return "用户名不存在！";
                case LoginEnum.PwdError:
                    return "密码与用户名不匹配！";
                case LoginEnum.NotActivated:
                    return "账户没有激活，请联系管理员";
                case LoginEnum.Ok:
                    LoginHelper.SaveLoginedUser(HttpContext, _userService.GetEntities(username));
                    return "ok";
                default:
                    return "未知错误请联系管理员！";
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public string Register(string email,string username,string password)
        {

            bool result= _userService.RegisterUser(email, username, password);
            if (result)
            {
                return "注册成功等待管理员批准！";
            }
            else {
                return "注册失败，请联系管理员！";
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void Logout()
        {
            LoginHelper.ClearUserSession(HttpContext);
            Response.Redirect("Login");
        }


    }
}
