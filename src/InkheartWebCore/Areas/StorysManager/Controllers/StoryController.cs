using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InkheartWeb.Infrastructure;
using InkheartWeb.Entities.StoryEntity;
using InkheartWeb.Common;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InkheartWebCore.Areas.StorysManager.Controllers
{
    [Area("StorysManager")]
    public class StoryController : Controller
    {
        StoryService _storyService;
        public StoryController()
        {
            _storyService = new StoryService();
        }
        // GET: /<controller>/
        /// <summary>
        /// 加载小说列表
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult  GetStoryListJson(int pageIndex,int pageSize)
        {
            int total;
            List<Book> storyList = _storyService.GetPageEntities(pageSize, pageIndex, out total,x=>true,x=>x.Id,false);
            ViewBag.total = total;
            return Json(new {storyList,total});
        }

        public JsonResult GetName_Values()
        {
            return Json(_storyService.GetViewModel("select Name,Id from Book"));
        }

        /// <summary>
        /// 添加小说
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View("StoryAdd");
            
        }

        [HttpPost]
        public bool Add(IFormCollection form)
        {
            Book book = new Book()
            {
                Name = form["name"],
                Author = form["author"],
                Channel = form["channel"],
                CreateTime = Convert.ToDateTime(form["date"]),
                Introduction = form["introduction"],
                Word_count = Convert.ToInt64(form["wordCount"]),
                GroupId = 1,
                ImageCover = "//storage.360buyimg.com/i.imageUpload/6a645f3536653165363937666262386331343537323631393931383039_sma.jpg",
                Price = Convert.ToDecimal(form["price"]),
                Tag = form["tag"],
                Title = form["title"],
                Type = form["type"],
                Url = form["url"],
                VIP = form["isVip"] == "on" ? true : false
            };
            _storyService.Add(book);
            return true;
        }

        public IActionResult Edit(string id)
        {
            long bookId = Convert.ToInt64(id);
            Book book = _storyService.GetEntities(x=>x.Id==bookId);

            return View("StoryAdd");
        }

        public bool Delete(long id)
        {
            return true;
        }


    }
}
