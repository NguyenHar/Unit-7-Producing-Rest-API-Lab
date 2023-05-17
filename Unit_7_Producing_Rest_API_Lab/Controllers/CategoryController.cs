using Microsoft.AspNetCore.Mvc;
using Unit_7_Producing_Rest_API_Lab.Models;

namespace Unit_7_Producing_Rest_API_Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        public NorthwndContext db = new NorthwndContext();

        [HttpGet("Categories")]
        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        [HttpGet("CategoryById")]
        public Category GetCategory(int id)
        {
            Category output = db.Categories.Find(id);
            if (output != null)
                return output;
            else
                return new Category() { CategoryName = $"Error: id {id} is not a valid id in the db, please try again" };
        }

        [HttpPost("AddCategory")]
        public string AddCategory(string name, string description)
        {
            Category category = new Category() { CategoryName = name, Description = description };
            db.Categories.Add(category);
            db.SaveChanges();
            return $"{category.CategoryName} was successfully added to the database";
        }
    }
}
