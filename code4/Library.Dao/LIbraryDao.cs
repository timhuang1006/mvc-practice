using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library.Dao
{
	public class LIbraryDao
	{
		/// <summary>
		/// 取得DB連線字串
		/// </summary>
		/// <returns></returns>
		private string GetDBConnectionString()
		{
			return Library.common.ConfigTool.GetDBConnectionString("DBConn");
				}
		/// <summary>
		/// 查詢
		/// </summary>
		/// <returns></returns>
		public List<Library.Model.serch> GetbooksByCondtioin(Library.Model.serch arg)
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

				cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", arg.Bookname == null ? string.Empty : arg.Bookname));
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", arg.bookcatorory == null ? string.Empty : arg.bookcatorory));
				cmd.Parameters.Add(new SqlParameter("@USER_ID", arg.bookuser == null ? string.Empty : arg.bookuser));
				cmd.Parameters.Add(new SqlParameter("@CODE_ID", arg.status == null ? string.Empty : arg.status));
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
		public int Insertbook(Library.Model.createbook insert)
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
				cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", insert.bookname));
				cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", insert.author));
				cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", insert.publisher));
				cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", insert.introduction));
				cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", insert.buydate));
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", insert.bookcatorory));
				add = Convert.ToInt32(cmd.ExecuteScalar());
				conn.Close();
			}
			return add;
		}

		/// <summary>
		/// 修改
		/// </summary>
		public void EditBook(Library.Model.editbook data)
		{
			string sql = @"UPDATE BOOK_DATA 
                           SET BOOK_NAME = @BOOK_NAME ,BOOK_AUTHOR = @BOOK_AUTHOR, 
                                BOOK_PUBLISHER = @BOOK_PUBLISHER, BOOK_NOTE = @BOOK_NOTE,
                                BOOK_BOUGHT_DATE = @BOOK_BOUGHT_DATE, BOOK_STATUS = @CODE_ID,
                                BOOK_CLASS_ID = @BOOK_CLASS_ID, BOOK_KEEPER = @BOOK_KEEPER
                           WHERE BOOK_ID = @BOOK_ID";
			using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", data.bookname));
				cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", data.author));
				cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", data.publisher));
				cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", data.introduction));
				cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", data.buydate));
				cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", data.bookcatorory));
				cmd.Parameters.Add(new SqlParameter("@CODE_ID", data.status));
				cmd.Parameters.Add(new SqlParameter("@BOOK_KEEPER", data.bookuser));
				cmd.Parameters.Add(new SqlParameter("@BOOK_ID", data.bookid));
				SqlTransaction trans = conn.BeginTransaction();
				cmd.Transaction = trans;

				try
				{
					cmd.ExecuteNonQuery();
					trans.Commit();
				}
				catch (Exception)
				{
					trans.Rollback();
					throw;
				}
				finally
				{
					conn.Close();
				}
			}

		}


		/// <summary>
		/// 刪除客戶
		/// </summary>
		public void DeleteBOOK(string BOOK_ID)
		{
			try
			{
				string sql = "Delete FROM BOOK_DATA Where BOOK_ID = @BOOK_ID";
				using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.Add(new SqlParameter("@BOOK_ID", BOOK_ID));
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private List<Library.Model.serch> MapserchDataToList(DataTable employeeData)
		{
			List<Library.Model.serch> result = new List<Library.Model.serch>();
			foreach (DataRow row in employeeData.Rows)
			{
				result.Add(new serch()
				{
					BOOK_ID = (int)row["BOOK_ID"],
					Bookname = row["BOOK_NAME"].ToString(),
					bookcatorory = row["BOOK_CLASS_NAME"].ToString(),
					bookuser = row["BOOK_BOUGHT_DATE"].ToString(),
					status = row["CODE_NAME"].ToString(),
					user = row["USER_ENAME"].ToString(),
				});
			}
			return result;
		}
	}
}