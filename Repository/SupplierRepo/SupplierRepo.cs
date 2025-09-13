using Inventory_Management_System.Model;
using Inventory_Management_System.Repository.GenericRepo;

namespace Inventory_Management_System.Repository.SupplierRepo
{
    public class SupplierRepo : GenericRepo<Supplier>,ISupplierRepo
    {
        public SupplierRepo(AppDbContext context) : base(context) { }
    }
}
