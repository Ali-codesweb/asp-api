using AutoMapper;
using bookstore.Data;
using bookstore.Models;

namespace bookstore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ApplicationDbContext, BooksModel>().ReverseMap();
        }
    }
}
