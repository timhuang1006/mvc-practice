using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
	public class createbook
	{
		/// <summary>
		/// 書名
		/// </summary>
		///
		[DisplayName("書名")]
		[Required(ErrorMessage = "此欄位必填")]
		public string bookname { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		///
		[DisplayName("作者")]
		[Required(ErrorMessage = "此欄位必填")]
		public string author { get; set; }

		/// <summary>
		/// 出版商
		/// </summary>
		///
		[DisplayName("出版商")]
		[Required(ErrorMessage = "此欄位必填")]
		public string publisher { get; set; }

		/// <summary>
		/// 內容簡介
		/// </summary>
		///
		[DisplayName("內容簡介")]
		[Required(ErrorMessage = "此欄位必填")]
		public string introduction { get; set; }

		/// <summary>
		/// 購書日期
		/// </summary>
		///
		[DisplayName("購書日期")]
		[Required(ErrorMessage = "此欄位必填")]
		public string buydate { get; set; }

		/// <summary>
		/// 圖書類別
		/// </summary>
		///
		[DisplayName("圖書類別")]
		[Required(ErrorMessage = "此欄位必填")]
		public string bookcatorory { get; set; }


	}
}