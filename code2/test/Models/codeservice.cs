using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace libmaintain.Models
{
	public class Codeservice
	{
		/// <summary>
		/// 取得DB連線字串
		/// </summary>
		/// <returns></returns>
		private string GetDBConnectionString()
		{
			return
				System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
		}
		/// <summary>
		/// 123
		/// </summary>
		/// <param name="catorory"></param>
		/// <returns></returns>
		public List<SelectListItem> GetBookClassName(string catorory)
		{
			DataTable dt = new DataTable();
			string sql = @"Select DISTINCT BOOK_CLASS_NAME AS CodeName, BOOK_CLASS_ID AS CodeId
                           FROM dbo.BOOK_CLASS
                           WHERE BOOK_CLASS_NAME != @BOOK_CLASS_NAME"; 
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_NAME", catorory));
				SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
				sqlAdapter.Fill(dt);
				conn.Close();
			}
			return this.MapCodeData(dt);
		}

		public List<SelectListItem> GetUerName(string bookuser)
		{
			DataTable dt = new DataTable();
			string sql = @"Select DISTINCT USER_ENAME AS CodeName, [USER_ID] AS CodeId
                           FROM MEMBER_M
                           WHERE USER_ENAME != @USER_ENAME"; 
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.Add(new SqlParameter("@USER_ENAME", bookuser));
				SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
				sqlAdapter.Fill(dt);
				conn.Close();
			}
			return this.MapCodeData(dt);
		}

		public List<SelectListItem> GetCodeName(string status)
		{
			DataTable dt = new DataTable();   //DISTINCT no need
			string sql = @"Select DISTINCT BCODE.CODE_NAME AS CodeName, BCODE.CODE_ID AS CodeId    
                           FROM BOOK_CODE BCODE
                           WHERE CODE_NAME != @CODE_NAME" ;
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.Add(new SqlParameter("@CODE_NAME", status));
				SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
				sqlAdapter.Fill(dt);
				conn.Close();
			}
			return this.MapCodeData(dt);
		}

		private List<SelectListItem> MapCodeData(DataTable dt)
		{
			List<SelectListItem> result = new List<SelectListItem>();
			foreach (DataRow row in dt.Rows)
			{
				result.Add(new SelectListItem()
				{
					Text =  row["CodeName"].ToString(),
					Value = row["CodeId"].ToString()
				});
			}
			return result;
		}

	}
}