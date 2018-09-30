using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Library.Service
{
	public class CodeService
	{
		public List<SelectListItem> GetBOOK_CLASS_NAME()
		{
			Library.Dao.Codedao codedao = new Dao.Codedao();
			return codedao.GetBOOK_CLASS_NAME();
		}

		public List<SelectListItem> GetUSER_ENAME()
		{
			Library.Dao.Codedao codedao = new Dao.Codedao();
			return codedao.GetUSER_ENAME();

		}

		public List<SelectListItem> GetCODE_NAME()
		{
			Library.Dao.Codedao codedao = new Dao.Codedao();
			return codedao.GetCODE_NAME();

		}


	}
}
