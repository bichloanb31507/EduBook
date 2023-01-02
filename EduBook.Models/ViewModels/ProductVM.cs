﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduBook.Models.ViewModels
{
    public class ProductVM
    {
        public Product? Product { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? CoverTypes { get; set; }
    }
}
