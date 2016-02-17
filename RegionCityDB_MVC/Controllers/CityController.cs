using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegionCityDB_MVC.Models;
namespace RegionCityDB_MVC.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        private RegionCityDB_MVC.DataLayer.DatabaseLayer.RegionCityEntities1 db = new DataLayer.DatabaseLayer.RegionCityEntities1();
        private const int ItemsPerPage = 10;
        public ActionResult Index(int id = 1)
        {
            var TotalItems = db.City.Count();
            PagingInfo paging = new PagingInfo() { CurrentPage = id, TotalItems = TotalItems, ItemsPerPage = ItemsPerPage };
            ViewBag.paging = paging;

            return View(db.City.OrderBy(p => p.CityName).Skip((id - 1) * ItemsPerPage).Take(ItemsPerPage));
        }

        public ActionResult TwoDropDown()
        {
            ViewBag.Region = db.Region.ToList();

            return View();
        }
        public JsonResult LoadCityByRegion(int id = 1)
        {
            var modelList = db.City.Where(p => p.RegionId == id);

            var modelData = modelList.Select(m => new SelectListItem()
            {
                Text = m.CityName,
                Value = m.CityId.ToString()

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
    }
}