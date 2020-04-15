using RedisCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisCache.Controllers
{
    public class DemoDropdownController : Controller
    {
        private readonly CacheStrigsStack _cacheStrigsStack;

        public DemoDropdownController()
        {
            _cacheStrigsStack = new CacheStrigsStack();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCountryList()
        {
            if (_cacheStrigsStack.IsKeyExists("countryList"))
            {
                var countryList = _cacheStrigsStack.GetList<List<CountryMaster>>("countryList");
                return Json(data: countryList, behavior: JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<CountryMaster> countryList;
                using (var db = new DatabaseContext())
                {
                    var countryListtemp = (from district in db.Countries
                                           select district).ToList();

                    _cacheStrigsStack.StoreList<List<CountryMaster>>("countryList", countryListtemp, TimeSpan.MaxValue);
                    countryList = _cacheStrigsStack.GetList<List<CountryMaster>>("countryList");
                }

                return Json(data: countryList, behavior: JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult GetStateList(int? countryId)
        {
            if (_cacheStrigsStack.IsKeyExists("stateList"))
            {
                var tempstateList = _cacheStrigsStack.GetList<List<StateMaster>>("stateList");
                var stateList = (from state in tempstateList
                                 where state.CountryId == countryId
                                 select state).ToList();

                return Json(data: stateList, behavior: JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<StateMaster> databasestateList;

                using (var db = new DatabaseContext())
                {
                    databasestateList = (from state in db.States
                                         select state).ToList();
                    _cacheStrigsStack.StoreList<List<StateMaster>>("stateList", databasestateList, TimeSpan.MaxValue);
                    databasestateList = databasestateList.Where(state => state.CountryId == countryId).ToList();
                }

                return Json(data: databasestateList, behavior: JsonRequestBehavior.AllowGet);
            }

        }
    }
}