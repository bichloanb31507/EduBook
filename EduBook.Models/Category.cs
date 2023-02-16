using System.ComponentModel.DataAnnotations;

namespace EduBook.Models
{
    // tạo class Category
    public class Category
    {
        // khoá chính Id
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public int Status { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}