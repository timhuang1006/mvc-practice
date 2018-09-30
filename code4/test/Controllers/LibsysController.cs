using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libmaintain.Controllers
{
    public class LibsysController : System.Web.Mvc.Controller
    {
		// GET: Libsys
		Models.codeservice codeservice = new Models.codeservice();
		
		/// <summary>
		///查詢bf
		/// </summary>
		/// <returns></returns>
		public ActionResult serch()
		{
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			ViewBag.USER_ENAME = this.codeservice.GetUSER_ENAME();
			ViewBag.CODE_NAME = this.codeservice.GetCODE_NAME();

			return View();
		}

		/// <summary>
		/// 查詢後
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult serch(Models.serch arg)
		{
			Models.service serch = new Models.service();
			ViewBag.SearchResult = serch.GetbooksByCondtioin(arg);
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			ViewBag.USER_ENAME = this.codeservice.GetUSER_ENAME();
			ViewBag.CODE_NAME = this.codeservice.GetCODE_NAME();
			return View( );
			//return Json(this.codeservice.GetBOOK_CLASS_NAME("BOOK_CLASS_NAME"));
		}

		[HttpPost]
		public JsonResult GetCatorogry()
		{
			List<SelectListItem> Catorogry = new List<SelectListItem>();
			Catorogry = codeservice.GetBOOK_CLASS_NAME();
			return Json(Catorogry);
		}

		[HttpPost]
		public JsonResult Getusernsame()
		{
			List<SelectListItem> usernsame = new List<SelectListItem>();
			usernsame = codeservice.GetUSER_ENAME();
			return Json(usernsame);
		}


		[HttpPost]
		public JsonResult GetStatus()
		{
			List<SelectListItem> status = new List<SelectListItem>();
			status = codeservice.GetCODE_NAME();
			return Json(status);
		}

		[HttpPost]
		public JsonResult Getdetials(Models.serch arg)
		{
			List<Models.serch> detials = new List<Models.serch>();
			Models.service serch = new Models.service();
			detials = serch.GetbooksByCondtioin(arg);
			return Json(detials);
		}

		/// <summary>
		/// 新增bf
		/// </summary>
		/// <returns></returns>
		public ActionResult create()
		{
			Models.createbook test = new Models.createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			return View();
		}
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="INSERT"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(Models.createbook INSERT)
		{
			Models.createbook test = new Models.createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			if (ModelState.IsValid)
			{
				Models.service insertsevice = new Models.service();
				if (INSERT.buydate != null)
					INSERT.buydate = INSERT.buydate.Replace(",", "");
				insertsevice.Insertbook(INSERT);
				TempData["message"] = "存檔成功";
			}
			return View();
		}


		public JsonResult Createdetials(Models.createbook insert)
		{
			int createdetials = new int();
			Models.service create = new Models.service();
			createdetials = create.Insertbook(insert);
			if (ModelState.IsValid)
			{
				Models.service insertsevice = new Models.service();
				insertsevice.Insertbook(insert);
			}
			return Json(createdetials);
		}

		/// <summary>
		/// 刪除 
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		[HttpPost()]
		public JsonResult Delete(string BOOK_ID)
		{
			try
			{
				Models.service delet = new Models.service();
				delet.DeleteBOOK(BOOK_ID);
				return this.Json(true);
			}

			catch (Exception ex)
			{
				return this.Json(false);
			}
		}
		/// <summary>
		/// 修改bf
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit()
		{
			Models.editbook test = new Models.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			ViewBag.CODE_NAME = this.codeservice.GetCODE_NAME();
			ViewBag.USER_ENAME = this.codeservice.GetUSER_ENAME();
			return View();
		}
		/// <summary>
		/// 修改後
		/// </summary>
		/// <param name="modify"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Edit(Models.editbook modify)
		{
			Models.editbook test = new Models.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME();
			ViewBag.CODE_NAME = this.codeservice.GetCODE_NAME();
			ViewBag.USER_ENAME = this.codeservice.GetUSER_ENAME();
			return View();
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="bookId"></param>
		/// <returns></returns>
		[HttpPost()]
		public ActionResult GetUpdateBookData(string bookId)
		{
			Models.codeservice findbookdata = new Models.codeservice();
			var editbookmodels = findbookdata.FindBookData(bookId).FirstOrDefault();
			return Json(editbookmodels);
		}
		[HttpPost()]
		public JsonResult ModifyBook(Models.editbook data)
		{
			Models.service updatebookdata = new Models.service();
			updatebookdata.EditBook(data);
			return Json("");
		}



	}
}

















///// <summary>
///// 資料查詢(查詢)
///// </summary>
///// <returns></returns>
//[HttpPost()]
//public ActionResult index(Models.serch arg)
//{
//	Models.service employeeService = new Models.service();
//	ViewBag.SearchResult = employeeService.GetbooksByCondtioin(arg);
//	ViewBag.BOOK_CLASS_NAME = this.codeservice.GetBOOK_CLASS_NAME("BOOK_CLASS_NAME");
//	ViewBag.USER_ENAME = this.codeservice.GetUSER_ENAME("USER_ENAME");
//	ViewBag.CODE_NAME = this.codeservice.GetCODE_NAME("CODE_NAME");
//	return View("serch");
//}