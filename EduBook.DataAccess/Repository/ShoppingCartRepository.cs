using EduBook.DataAccess.Data;
using EduBook.DataAccess.Repository.IRepository;
using EduBook.Models;

namespace EduBook.DataAccess.Repository
{
    // tạo class ShoppingCartRepository
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart obj)
        {
            _db.Update(obj);
        }
    }
}