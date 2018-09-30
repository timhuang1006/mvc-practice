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
		Models.Codeservice codeService = new Models.Codeservice();
		
		/// <summary>
		///查詢bf
		/// </summary>
		/// <returns></returns>
		public ActionResult Search()
		{
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			ViewBag.USER_ENAME = this.codeService.GetUerName("USER_ENAME");
			ViewBag.CODE_NAME = this.codeService.GetCodeName("CODE_NAME");

			return View();
		}

		/// <summary>
		/// 查詢後
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Search(Models.Search arg)
		{
			Models.Service search = new Models.Service();
			ViewBag.SearchResult = search.GetbooksByCondtioin(arg);
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			ViewBag.USER_ENAME = this.codeService.GetUerName("USER_ENAME");
			ViewBag.CODE_NAME = this.codeService.GetCodeName("CODE_NAME");
			return View( );
		}

		/// <summary>
		/// 新增前
		/// </summary>
		/// <returns></returns>
		public ActionResult Create()
		{
			Models.Createbook test = new Models.Createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			return View();
		}
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="INSERT"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(Models.Createbook insertdata)
		{
			Models.Createbook test = new Models.Createbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			if (ModelState.IsValid)
			{
				Models.Service insertsevice = new Models.Service();
				if (insertdata.BuyDate != null)
					insertdata.BuyDate = insertdata.BuyDate.Replace(",", "");
				insertsevice.Insertbook(insertdata);
				TempData["message"] = "存檔成功";
			}
			return View();
		}

		/// <summary>
		/// 刪除 
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		[HttpPost()]
		public JsonResult Delete(string bookid)
		{
			try
			{
				Models.Service delet = new Models.Service();
				delet.DeleteBook(bookid);
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
		public ActionResult edit()
		{
			Models.editbook test = new Models.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			ViewBag.CODE_NAME = this.codeService.GetCodeName("CODE_NAME");
			ViewBag.USER_ENAME = this.codeService.GetUerName("USER_ENAME");
			return View();
		}
		/// <summary>
		/// 修改後
		/// </summary>
		/// <param name="modify"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult edit(Models.editbook modify)
		{
			Models.editbook test = new Models.editbook();
			ViewBag.BOOK_CLASS_NAME = this.codeService.GetBookClassName("BOOK_CLASS_NAME");
			ViewBag.CODE_NAME = this.codeService.GetCodeName("CODE_NAME");
			ViewBag.USER_ENAME = this.codeService.GetUerName("USER_ENAME");
			return View();
		}

		public ActionResult Js()
		{
			return Content("hell");
		}



	}
}


















///// <summary>
///// 資料查詢(查詢)
///// </summary>
///// <returns></returns>
//[HttpPost()]
//public ActionResult index(Models.Search arg)
//{
//	Models.Service employeeService = new Models.Service();
//	ViewBag.SearchResult = employeeService.GetbooksByCondtioin(arg);
//	ViewBag.BOOK_CLASS_NAME = this.Codeservice.GetBookClassName("BOOK_CLASS_NAME");
//	ViewBag.USER_ENAME = this.Codeservice.GetUerName("USER_ENAME");
//	ViewBag.CODE_NAME = this.Codeservice.GetCodeName("CODE_NAME");
//	return View("Search");
//}