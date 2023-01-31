using AutoMapper;
using bookstore.Data;
using bookstore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BookRepository(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            /*var records = await  context.Book.Select(x=>new BooksModel()
            {
                Id = x.Id,
                Description = x.Description,    
                Title = x.Title,    
            }).ToListAsync();
            return records;*/
            var books = await context.Book.ToListAsync();
            return mapper.Map<List<BooksModel>>(books);
        }
        public async Task<BooksModel> GetBookByIdAsync(int id)
        {
            /* var records = await context.Book.Where(x=>x.Id == id).Select(x => new BooksModel()
             {
                 Id = x.Id,
                 Description = x.Description,
                 Title = x.Title,
             }).FirstOrDefaultAsync();
             return records;*/

            var book = await context.Book.FindAsync(id);
            return mapper.Map<BooksModel>(book);
        }

        public async Task<int> AddBookAsync(BooksModel bookModel)
        {
            var book = new BooksModel()
            {
                Description = bookModel.Description,
                Title = bookModel.Title
            };
            context.Book.AddAsync(book);
            await context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBookAsync(int id,BooksModel bookModel)
        {
            /*var book = await context.Book.FindAsync(id);
            if(book != null)
            {
                book.Description = bookModel.Description;
                book.Title = bookModel.Title;
                await context.SaveChangesAsync();
            }   */

            var book = new BooksModel()
            {
                Id=id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            context.Book.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument bookModel)
        {
            var book = await context.Book.FindAsync(id);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int id)
        {
            /*var book = context.Book.Where(x => x.Id == id).FirstOrDefault();
            context.Book.Remove(book);*/

            var book = new BooksModel()
            {
                Id = id
            };
            context.Book.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
