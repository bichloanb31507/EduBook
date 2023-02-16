using EduBook.DataAccess.Repository.IRepository;
using EduBook.Models;
using EduBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduBook.Areas.Admin.Controllers
{
    // phân quyền admin
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // GET
        public IActionResult Upsert(int? id) // khi bấm là insert (1) thì id là null vì trên url kh có giá trị, ngược lại bấm update (2)
        {
            Category category = new Category(); // khởi tạo đối tượng category với dữ liệu mặc định: id = 0; name = null, status = 0, datetime giờ hiện tại (1)(2)
            if (id == null) { // nếu id = null (1) (2)
                return View(category); // chuyển vào form insert
            }
            category = _unitOfWork.Category.Get(id.GetValueOrDefault()); // kiểm tra xem có đối tượng chứa id đó không (2)
            if (category == null) // nếu không tìm thấy (2)
            {
                return NotFound(); // không trả về gì cả (2)
            }
            // còn nếu tìm thấy thì trả form update với dữ liệu là category (2)
            return View(category);
        }

        //GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj }); // dữ liệu dạng json -> index của category
        }

        // API
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting!" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully" });

        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid) 
            { 
                if (category.Id == 0) 
                {
                    _unitOfWork.Category.Add(category);
                    TempData["success"] = "Added Successfully";
                } 
                else
                {
                    _unitOfWork.Category.Update(category);
                    TempData["success"] = "Updated Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}