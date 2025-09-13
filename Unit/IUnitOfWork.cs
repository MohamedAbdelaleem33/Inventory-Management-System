using Inventory_Management_System.Model;
using Inventory_Management_System.Repository.CategoryRepo;
using Inventory_Management_System.Repository.GenericRepo;
using Inventory_Management_System.Repository.ProductRepo;
using Inventory_Management_System.Repository.SupplierRepo;

namespace Inventory_Management_System.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        ProductRepo ProductRepo { get; } 
        CategoryRepo CategoryRepo { get; }
        SupplierRepo SupplierRepo { get; }

        Task<int> SaveChangesAsync();                           
    }
}
