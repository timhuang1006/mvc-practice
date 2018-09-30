using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace libmaintain.Models
{
	public class Createbook
	{
		/// <summary>
		/// 書名
		/// </summary>
		///
		[DisplayName("書名")]
		[Required(ErrorMessage = "此欄位必填")]
		public string  BookName{ get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		///
		[DisplayName("作者")]
		[Required(ErrorMessage = "此欄位必填")]
		public string  Author{ get; set; }

		/// <summary>
		/// 出版商
		/// </summary>
		///
		[DisplayName("出版商")]
		[Required(ErrorMessage = "此欄位必填")]
		public string  Publisher{ get; set; }

		/// <summary>
		/// 內容簡介
		/// </summary>
		///
		[DisplayName("內容簡介")]
		[Required(ErrorMessage = "此欄位必填")]
		public string  Introduction{ get; set; }

		/// <summary>
		/// 購書日期
		/// </summary>
		///
		[DisplayName("購書日期")]
		[Required(ErrorMessage = "此欄位必填")]
		public string  BuyDate{ get; set; }

		/// <summary>
		/// 圖書類別
		/// </summary>
		///
		[DisplayName("圖書類別")]
		[Required(ErrorMessage = "此欄位必填")]
		public string BookCatorory { get; set; }


	}
}