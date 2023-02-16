using EduBook.DataAccess.Data;
using EduBook.DataAccess.Repository.IRepository;
using EduBook.Models;

namespace EduBook.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}