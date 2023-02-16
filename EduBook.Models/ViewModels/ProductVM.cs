using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduBook.Models.ViewModels
{
    // tạo class trung gian ProductVM
    public class ProductVM
    {
        public Product? Product { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? CoverTypes { get; set; }
    }
}