using Bulky.DataAccess.Data;
using Bulky.Models;

using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
			List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

     public IActionResult Create()
		{

			return View();
		}
   

		[HttpPost]
		public IActionResult Create(Category  obj)
		{

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            }
			//if (obj.Name != null && obj.Name.ToLower() == "test")
			//{
			//    ModelState.AddModelError("", "Test is an invalid value");
			//}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				//TempData["error"] = "Unable to create";
				return RedirectToAction("Index");
			}
			
			return View();

		}
		
		public IActionResult Edit(int? Id)
		{
			if (Id == null || Id == 0)
			{

				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(Id);
			// Category? categoryFromDb1 =_db.Categories.FirstOrDefault(u=>u.Id==id);
			// Category? categoryFromDb2 =_db.Categories.where(u=>u.Id==id).FirstOrDefault

			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);

		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
            

			if (ModelState.IsValid)
			{
				//var category = _db.Categories.Find(obj.Id);
				//if (category == null) { 
				//	return NotFound();
				//}
				//category.Name = string.IsNullOrEmpty(obj.Name)? category.Name: obj.Name;
				//category.DisplayOrder = obj.DisplayOrder == 0 ? category.DisplayOrder : obj.DisplayOrder;

				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully";

				return RedirectToAction("Index");
			}
			return View();

		}


		public IActionResult Delete(int? Id)
		{
			if (Id == null || Id == 0)
			{

				return NotFound();
			}
			Category categoryFromDb = _db.Categories.Find(Id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);

		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? Id)
		{

			Category? obj = _db.Categories.Find(Id);

			if (obj == null )
			{

				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");

		}



	}
}
