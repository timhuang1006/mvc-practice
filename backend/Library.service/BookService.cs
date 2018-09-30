using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
	public class BookService
	{

		public int Insertbook(Library.Model.createbook insert)
		{
			Library.Dao.LIbraryDao LIbraryDao = new Dao.LIbraryDao();
			return LIbraryDao.Insertbook(insert);

		}

		public List<Library.Model.serch> GetbooksByCondtioin(Library.Model.serch arg)
		{
			Library.Dao.LIbraryDao LIbraryDao = new Dao.LIbraryDao();
			return LIbraryDao.GetbooksByCondtioin(arg);
		}

		public void EditBook(Library.Model.editbook data)
		{
			Library.Dao.LIbraryDao LIbraryDao = new Dao.LIbraryDao();
			LIbraryDao.EditBook(data);
		}

		public void DeleteBOOK(string BOOK_ID)
		{
			Library.Dao.LIbraryDao LIbraryDao = new Dao.LIbraryDao();
			LIbraryDao.DeleteBOOK(BOOK_ID);
		}

	}
}
