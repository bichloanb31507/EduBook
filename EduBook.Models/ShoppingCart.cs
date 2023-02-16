using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBook.Models
{
    // tạo class ShoppingCart
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }

        // khoá chính Id
        [Key]
        public int Id { get; set; }
        // khoá ngoại ApplicationUserId -> ApplicationUser
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }
        // khoá ngoại ProductId -> Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [Range(1,1000,ErrorMessage = "Please enter a value between 1 and 1000!")]
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}