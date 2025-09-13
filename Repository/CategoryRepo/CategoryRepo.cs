using Inventory_Management_System.Model;
using Inventory_Management_System.Repository.GenericRepo;

namespace Inventory_Management_System.Repository.CategoryRepo
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context): base(context) { }

    }
}
