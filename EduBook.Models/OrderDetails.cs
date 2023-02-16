using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBook.Models
{
    // tạo class OrderDetails
    public class OrderDetails
    {
        // khoá chính Id
        [Key]
        public int Id { get; set; }
        // khoá ngoại OrderId -> OrderHeader
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader? OrderHeader { get; set; }
        // khoá ngoại ProductId -> Product
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}