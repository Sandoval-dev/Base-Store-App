using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);


        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,
            bool truckChanges)
        {
             var books= await FindAll(truckChanges)
            .OrderBy(b => b.Id)
            .ToListAsync();

            return PagedList<Book>.ToPagedList(books,bookParameters.PageNumber,bookParameters.PageSize);
        }
  
        public async Task<Book> GetOneBookByIdAsync(int id, bool truckChanges) => await FindByCondition(b=>b.Id.Equals(id), truckChanges).SingleOrDefaultAsync();


        public void UpdateOneBook(Book book)=>Update(book);

    }
}
