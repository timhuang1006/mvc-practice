using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
	public class jsController : Controller
	{
		// GET: js
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public JsonResult Gettestdata(string teststring)
		{
			return Json(teststring + "call ajax success!");

		}
		[HttpPost]
		public JsonResult Gettestdatadropdownlist()
		{
			List<string> tempdata = new List<string>();
			tempdata.Add("項目一");
			tempdata.Add("項目二");
			return Json(tempdata);
		}
    }
}