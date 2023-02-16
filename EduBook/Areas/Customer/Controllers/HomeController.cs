using EduBook.DataAccess.Repository.IRepository;
using EduBook.Models;
using EduBook.Models.ViewModels;
using EduBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EduBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            // lấy danh sách tất cả sản phẩm bao gồm thuộc tính Category, CoverType
            IEnumerable<Product> productList = _db.Product.GetAll(includeProperties: "Category,CoverType");
            // kiểm tra người dùng có đăng nhập hay không
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // nếu đăng nhập rồi
            if (claim != null)
            {
                // lấy số lượng sản phẩm tồn tại trong giỏ hàng của người dùng
                var count = _db.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count();
                // lưu số lượng giỏ hàng bằng session
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
            }
            return View(productList); // truyền danh sách tất cả sản phẩm ra Index
        }

        public IActionResult Details(int id)
        {
            // lấy sản phẩm bao gồm thuộc tính Category, CoverType
            var productFromDb = _db.Product.
                        GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType");
            // lưu product và product id qua model trung gian ShoppingCart
            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = productFromDb,
                ProductId = productFromDb.Id
            };
            return View(cartObj); // truyền ShoppingCart ra Details
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                // kiểm tra người dùng đăng nhập hay chưa
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value; // gán id user xác định giỏ hàng

                // lấy danh sách sản phẩm tồn tại trong giỏ hàng của người dùng
                ShoppingCart cartFromDb = _db.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == CartObject.ApplicationUserId && u.ProductId == CartObject.ProductId
                    , includeProperties: "Product"
                    );

                if (cartFromDb == null)
                {
                    // nếu giỏ hàng chưa có gì thì thêm vào
                    _db.ShoppingCart.Add(CartObject);
                }
                else
                {
                    // ngược lại thì cộng dồn số lượng sản phẩm
                    cartFromDb.Count += CartObject.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _db.Save();

                // chúng ta sẽ lấy số lượng sản phẩm tồn tại trong giỏ hàng
                var count = _db.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == CartObject.ApplicationUserId)
                    .ToList().Count();
                // cập nhật số lượng giỏ hàng ở session
                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // nếu dữ liệu không hợp lệ thì giữ nguyên trạng thái ban đầu
                var productFromDb = _db.Product.
                        GetFirstOrDefault(u => u.Id == CartObject.ProductId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.Id
                };
                return View(cartObj);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}