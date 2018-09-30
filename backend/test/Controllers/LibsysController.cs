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
		Library.Service.CodeService codeService= new Library.Service.CodeService();
		Library.Service.BookService bookService = new Library.Service.BookService();

		/// <summary>
		///查詢bf
		/// </summary>
		/// <returns></returns>
		public ActionResult serch()
		{
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			ViewBag.USER_ENAME = this.codeService.GetUSER_ENAME();
			ViewBag.CODE_NAME = this.codeService.GetCODE_NAME();

			return View();
		}

		/// <summary>
		/// 查詢後
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult serch(Library.Model.serch arg)
		{
			ViewBag.SearchResult = bookService.GetbooksByCondtioin(arg);
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			ViewBag.USER_ENAME = this.codeService.GetUSER_ENAME();
			ViewBag.CODE_NAME = this.codeService.GetCODE_NAME();
			return View( );
			//return Json(this.codeService.GetBOOK_CLASS_NAME("BOOK_CLASS_NAME"));
		}

		[HttpPost]
		public JsonResult GetCatorogry()
		{
			List<SelectListItem> Catorogry = new List<SelectListItem>();
			Catorogry = this.codeService.GetBOOK_CLASS_NAME();
			return Json(Catorogry);
		}

		[HttpPost]
		public JsonResult Getusernsame()
		{
			List<SelectListItem> usernsame = new List<SelectListItem>();
			usernsame = this.codeService.GetUSER_ENAME();
			return Json(usernsame);
		}


		[HttpPost]
		public JsonResult GetStatus()
		{
			List<SelectListItem> status = new List<SelectListItem>();
			status = this.codeService.GetCODE_NAME();
			return Json(status);
		}

		[HttpPost]
		public JsonResult Getdetials(Library.Model.serch arg)
		{
			List<Library.Model.serch> detials = new List<Library.Model.serch>();
			detials = bookService.GetbooksByCondtioin(arg);
			return Json(detials);
		}

		/// <summary>
		/// 新增bf
		/// </summary>
		/// <returns></returns>
		public ActionResult create()
		{
			Library.Model.createbook test = new Library.Model.createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			return View();
		}
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="INSERT"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(Library.Model.createbook INSERT)
		{
			Library.Model.createbook test = new Library.Model.createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			if (ModelState.IsValid)
			{
				if (INSERT.buydate != null)
					INSERT.buydate = INSERT.buydate.Replace(",", "");
				bookService.Insertbook(INSERT);
				TempData["message"] = "存檔成功";
			}
			return View();
		}


		public JsonResult Createdetials(Library.Model.createbook insert)
		{
			int createdetials = new int();
			createdetials = bookService.Insertbook(insert);
			if (ModelState.IsValid)
			{
				bookService.Insertbook(insert);
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
				bookService.DeleteBOOK(BOOK_ID);
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
			Library.Model.editbook test = new Library.Model.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			ViewBag.CODE_NAME = this.codeService.GetCODE_NAME();
			ViewBag.USER_ENAME = this.codeService.GetUSER_ENAME();
			return View();
		}
		/// <summary>
		/// 修改後
		/// </summary>
		/// <param name="modify"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Edit(Library.Model.editbook modify)
		{
			Library.Model.editbook test = new Library.Model.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME();
			ViewBag.CODE_NAME = this.codeService.GetCODE_NAME();
			ViewBag.USER_ENAME = this.codeService.GetUSER_ENAME();
			return View();
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="bookId"></param>
		/// <returns></returns>
		//[HttpPost()]
		//public ActionResult GetUpdateBookData(string bookId)
		//{
		//	var editbookmodels = bookService.FindBookData(bookId).FirstOrDefault();
		//	return Json(editbookmodels);
		//}
		//[HttpPost()]
		//public JsonResult ModifyBook(Models.editbook data)
		//{
		//	Models.service updatebookdata = new Models.service();
		//	updatebookdata.EditBook(data);
		//	return Json("");
		//}



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
//	ViewBag.BOOK_CLASS_NAME = this.codeService.GetBOOK_CLASS_NAME("BOOK_CLASS_NAME");
//	ViewBag.USER_ENAME = this.codeService.GetUSER_ENAME("USER_ENAME");
//	ViewBag.CODE_NAME = this.codeService.GetCODE_NAME("CODE_NAME");
//	return View("serch");
//}