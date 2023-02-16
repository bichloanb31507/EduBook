namespace EduBook.Models.ViewModels
{
    // tạo class trung gian ShoppingCartVM
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart>? ListCart { get; set; }
        public OrderHeader? OrderHeader { get; set; }
    }
}