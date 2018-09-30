using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace libmaintain.Models
{
	public class Search
	{
		/// <summary>
		/// 書名
		/// </summary>
		///[MaxLength(5)]
		[DisplayName("書名")]
		public string BookName { get; set; }

		/// <summary>
		/// 圖書類別
		/// </summary>
		[DisplayName("圖書類別")]
		public string BookCatorory { get; set; }
		
		
		/// <summary>
		/// 借閱人 
		/// </summary>
		[DisplayName("借閱人")]
		 
		public string BookUser { get; set; }

		/// <summary>
		/// 借閱狀態
		/// </summary>
		[DisplayName("借閱狀態")]
		public string Status { get; set; }

		public string User { get; set; }

		public int BookId { get; set; }
	}
}