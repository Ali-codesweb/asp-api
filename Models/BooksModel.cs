using System.ComponentModel.DataAnnotations;
namespace bookstore.Models
{
    public class BooksModel
    {
            public int Id { get; set; }
            [Required(ErrorMessage ="Pkease add title")]
            //[StringLength(100,ErrorMessage ="Strong lenfth myst be below 100")]
            //[EmailAddress]
            
            public string Title { get; set; }
            public string Description { get; set; }
    }
}
