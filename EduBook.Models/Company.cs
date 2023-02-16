using System.ComponentModel.DataAnnotations;

namespace EduBook.Models
{
    // tạo class Company
    public class Company
    {
        // khóa chính Id
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsAuthorizedCompany { get; set; }
    }
}