using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; set; }
}
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    [ForeignKey("Author")]
    public int AuthorId { get; set; }
    
    
}

}