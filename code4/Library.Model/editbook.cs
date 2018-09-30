using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
	public class editbook
	{
		/// <summary>
		/// 書名
		/// </summary>
		///
		[DisplayName("書名")]
		public string bookname { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		///
		[DisplayName("作者")]
		public string author { get; set; }

		/// <summary>
		/// 出版商
		/// </summary>
		///
		[DisplayName("出版商")]
		public string publisher { get; set; }

		/// <summary>
		/// 內容簡介
		/// </summary>
		///
		[DisplayName("內容簡介")]
		public string introduction { get; set; }

		/// <summary>
		/// 購書日期
		/// </summary>
		///
		[DisplayName("購書日期")]
		public string buydate { get; set; }

		/// <summary>
		/// 圖書類別
		/// </summary>
		///
		[DisplayName("圖書類別")]
		public string bookcatorory { get; set; }


		/// <summary>
		/// 借閱狀態
		/// </summary>
		[DisplayName("借閱狀態")]
		public string status { get; set; }

		/// <summary>
		/// 借閱人 
		/// </summary>
		[DisplayName("借閱人")]

		public string bookuser { get; set; }

		public int bookid { get; set; }
	}
}