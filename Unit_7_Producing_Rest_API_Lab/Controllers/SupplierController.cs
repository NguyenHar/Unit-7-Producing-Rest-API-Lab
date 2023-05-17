using Microsoft.AspNetCore.Mvc;
using Unit_7_Producing_Rest_API_Lab.Models;

namespace Unit_7_Producing_Rest_API_Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        public NorthwndContext db = new NorthwndContext();

        [HttpGet("GetCompanies")]
        public List<string> GetCompanies()
        {
            List<string> output = db.Suppliers.Select(x => x.CompanyName).ToList();
            return output;
        }

        [HttpGet("GetAllCompaniesInfo")]
        public List<Supplier> GetAllSuppliersInfo()
        {
            return db.Suppliers.ToList();
        }

        [HttpGet("GetSupplierById/{id}")]
        public Supplier GetSupplierById(int id)
        {
            Supplier output = db.Suppliers.Find(id);
            if (output != null)
                return output;
            else
                return new Supplier() { CompanyName = $"Error: id {id} is not a valid id in the db, please try again" };
        }
    }
}
