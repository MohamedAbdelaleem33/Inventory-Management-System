using Inventory_Management_System.DTOs;
using Inventory_Management_System.Model;

namespace Inventory_Management_System.Repository.ProductRepo
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetFilteredProducts(ProductView filter);
    }
}
