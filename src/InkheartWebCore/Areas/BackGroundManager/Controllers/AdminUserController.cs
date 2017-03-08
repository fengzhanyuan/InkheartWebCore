using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InkheartWeb.Entities.AdminUserEntity;
using InkheartWeb.Infrastructure.AdminManager;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InkheartWebCore.Areas.BackGroundManager.Controllers
{
    [Area("BackGroundManager")]
    public class AdminUserController : Controller
    {
        private AdminUserService _adminUserService;
        public AdminUserController()
        {
            _adminUserService = new AdminUserService();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAdminListJson(int pageIndex, int pageSize)
        {
            int total;
            List<AdminUser> storyList = _adminUserService.GetPageEntities(pageSize, pageIndex, out total, x => true, x => x.Id, false);
            ViewBag.total = total;
            return Json(new { storyList, total });
        }


    }
}
