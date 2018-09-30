using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
	public class serch
	{
		/// <summary>
		/// 書名
		/// </summary>
		///[MaxLength(5)]
		[DisplayName("書名")]
		public string Bookname { get; set; }

		/// <summary>
		/// 圖書類別
		/// </summary>
		[DisplayName("圖書類別")]
		public string bookcatorory { get; set; }


		/// <summary>
		/// 借閱人 
		/// </summary>
		[DisplayName("借閱人")]

		public string bookuser { get; set; }

		/// <summary>
		/// 借閱狀態
		/// </summary>
		[DisplayName("借閱狀態")]
		public string status { get; set; }

		public string user { get; set; }

		public int BOOK_ID { get; set; }
	}
}
