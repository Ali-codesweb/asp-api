using bookstore.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace bookstore.Repository
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BooksModel bookModel);
        Task UpdateBookAsync(int id, BooksModel bookModel);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int id);
    }
}