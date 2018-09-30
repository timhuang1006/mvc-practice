using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace libmaintain.Models
{
	public class Service
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
		/// 查詢
		/// </summary>
		/// <returns></returns>
		public List<Models.Search> GetbooksByCondtioin(Models.Search arg)
		{
			DataTable dt = new DataTable();
			string sql = @"SELECT BD.BOOK_ID, BD.BOOK_NAME, BC.BOOK_CLASS_NAME, BD.BOOK_BOUGHT_DATE, BCODE.CODE_NAME, M.USER_ENAME
						FROM BOOK_DATA BD 
						     JOIN BOOK_CLASS BC ON BD.BOOK_CLASS_ID = BC.BOOK_CLASS_ID
					         JOIN BOOK_CODE BCODE ON (BD.BOOK_STATUS = BCODE.CODE_ID AND CODE_TYPE = 'BOOK_STATUS')
							 LEFT JOIN MEMBER_M M ON BD.BOOK_KEEPER = M.[USER_ID]
							 WHERE (BD.BOOK_NAME LIKE ('%' + @BOOK_NAME + '%')  OR @BOOK_NAME='')AND (BD.BOOK_CLASS_ID = @BOOK_CLASS_ID OR @BOOK_CLASS_ID='')
                                AND (M.USER_ID = @USER_ID OR @USER_ID='') AND (BCODE.CODE_ID = @CODE_ID OR @CODE_ID='')";
			
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);

				cmd.Parameters.Add(new SqlParameter("@BOOK_NAME",arg.BookName == null ? string.Empty : arg.BookName));
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", arg.BookCatorory == null ? string.Empty : arg.BookCatorory));
				cmd.Parameters.Add(new SqlParameter("@USER_ID", arg.BookUser == null ? string.Empty : arg.BookUser));
				cmd.Parameters.Add(new SqlParameter("@CODE_ID", arg.Status == null ? string.Empty : arg.Status));
				SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
				sqlAdapter.Fill(dt);
				conn.Close();
			}
			return this.MapserchDataToList(dt);
		}
		/// <summary>
		/// 新增員工
		/// </summary>
		/// <param name="employee"></param>
		/// <returns></returns>
		public int Insertbook(Models.Createbook insert)
		{
			string sql = @" INSERT INTO BOOK_DATA
						 (
							 BOOK_NAME, BOOK_AUTHOR, BOOK_PUBLISHER, BOOK_NOTE, BOOK_BOUGHT_DATE, BOOK_CLASS_ID,BOOK_STATUS,BOOK_KEEPER
                            
						 )
						VALUES
						(
							 @BOOK_NAME, @BOOK_AUTHOR, @BOOK_PUBLISHER, @BOOK_NOTE, @BOOK_BOUGHT_DATE, @BOOK_CLASS_ID,'A',' '
						)
						Select SCOPE_IDENTITY()";
			int add;
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", insert.BookName));
				cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", insert.Author));
				cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", insert.Publisher));
				cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", insert.Introduction));
				cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", insert.BuyDate));
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", insert.BookCatorory));
				add = Convert.ToInt32(cmd.ExecuteScalar());
				conn.Close();
			}
			return add;
		}

		/// <summary>
		/// 刪除客戶
		/// </summary>
		public void DeleteBook(string bookid)
		{
			try
			{
				string sql = "Delete FROM BOOK_DATA Where BOOK_ID = @BOOK_ID";
				using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.Add(new SqlParameter("@BOOK_ID", bookid));
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private List<Models.Search> MapserchDataToList(DataTable employeeData)
		{
			List<Models.Search> result = new List<Search>();
			foreach (DataRow row in employeeData.Rows)
			{
				result.Add(new Search()
				{
					BookId = (int)row["BOOK_ID"],
					BookName = row["BOOK_CLASS_NAME"].ToString(),
					BookCatorory = row["BOOK_NAME"].ToString(),
					BookUser = row["BOOK_BOUGHT_DATE"].ToString(),
					Status = row["CODE_NAME"].ToString(),
					User = row["USER_ENAME"].ToString(),
				});
			}
			return result;
		}
	}
}