using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InkheartWeb.Infrastructure.ChapterManager;
using InkheartWeb.Entities.ChapterEntity;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InkheartWebCore.Areas.ChapterManager.Controllers
{
    [Area("ChapterManager")]
    public class ChapterController : Controller
    {
        ChapterService _chapterService;
        public ChapterController()
        {
            _chapterService = new ChapterService();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChapterDetails(long id)
        {
            ViewBag.id = id;
            return View("ChapterDetails");
        }

        public IActionResult GetChapterListJson(long id, int volumeNo)
        {
            List<Chapter> chapterList = _chapterService.GetAllEntities(x => (x.FatherId == id && x.VolumeNo == volumeNo));
            return Json(chapterList);
        }

        [HttpPost]
        public JsonResult GetDetails(long id)
        {
            Chapter chapter = _chapterService.GetAllEntities(x => (x.Id == id)).FirstOrDefault();
            return Json(chapter);
        }

        public bool Delete(long id)
        {
            bool result = _chapterService.Delete(x => x.Id == id);
            return result;
        }

        public IActionResult Add()
        {
            return View("AddChapter");

        }

        [HttpPost]
        public bool Add(IFormCollection form)
        {
            Chapter chapter = new Chapter()
            {
                VolumeNo = Convert.ToInt32(form["volumeNo"]),
                Body = form["chapterTxt"],
                ChapterNo = Convert.ToInt32(form["chapterNo"]),
                Date = DateTime.Now,
                ChapterTxt = form["chapterName"],
                FatherId = Convert.ToInt64(form["fatherId"]),
            };
            return _chapterService.Add(chapter) != null;
        }
    }


}

