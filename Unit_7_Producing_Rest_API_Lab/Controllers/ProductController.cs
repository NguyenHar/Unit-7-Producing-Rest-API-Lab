using Microsoft.AspNetCore.Mvc;
using Unit_7_Producing_Rest_API_Lab.Models;

namespace Unit_7_Producing_Rest_API_Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public NorthwndContext db = new NorthwndContext();
        [HttpGet("WelcomeProduct")]
        public string GetWelcomeMessage()
        {
            return "Welcome to the Product list API";
        }

        [HttpGet("Product/{id}")]
        public Product GetProduct(int id)
        {
            Product output = db.Products.Find(id);
            if (output != null)
                return output;
            else
                return new Product() { ProductName = $"Error: id {id} was not found in the database, please try again" };
        }

        [HttpGet("ProductCount")]
        public int GetProductCount()
        {
            return db.Products.Count();
        }

        [HttpGet("AveragePricePerUnit")]
        public decimal? GetProductAverage()
        {
            return db.Products.Average(x => x.UnitPrice);
        }

        [HttpPost("NewProduct/{name}/{supplierID}/{categoryID}/{QtyPerUnit}/{UnitPrice}/{UnitsInStock}/{UnitsOnOrder}/{ReorderLevel}/{Discontinued}")]
        public string AddProduct(string name, int supplierID, int categoryID, string QtyPerUnit, decimal UnitPrice, short UnitsInStock, short UnitsOnOrder, short ReorderLevel, bool Discontinued)
        {
            Product product = new Product()
            {
                ProductName = name,
                SupplierId = supplierID,
                CategoryId = categoryID,
                QuantityPerUnit = QtyPerUnit,
                UnitPrice = UnitPrice,
                UnitsInStock = UnitsInStock,
                UnitsOnOrder = UnitsOnOrder,
                ReorderLevel = ReorderLevel,
                Discontinued = Discontinued
            };
            db.Products.Add(product);
            db.SaveChanges();
            return $"Product {name} was successfully added to the database";
        }

        [HttpDelete("RemoveProductById/{id}")]
        public string RemoveProduct(int id)
        {
            Product prodToDel = db.Products.Find(id);
            if (prodToDel != null)
            {
                db.Products.Remove(prodToDel);
                db.SaveChanges();
                return $"{prodToDel.ProductName} with id {id} was successfully removed from the database";
            }
            else
                return $"There was no product wih id {id} in the database, no changes made";
        }
    }
}
