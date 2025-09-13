using Inventory_Management_System.DTOs;
using Inventory_Management_System.Model;
using Inventory_Management_System.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Repository.ProductRepo
{
    public class ProductRepo : GenericRepo<Product>,IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context) { }
        
        public async Task<IEnumerable<Product>> GetFilteredProducts(ProductView filter)
        {
            IQueryable<Product> query = _dbSet.AsQueryable(); //same as _context.Products.AsQueryable as already dbset defines that this is product table 
            if (!string.IsNullOrEmpty(filter.Name)) {
              query = query.Where(p => p.Name.Contains(filter.Name));
            } //filteration using name
            //if(filter.price != null)
           // {
           //   query = query.Where(p => p.price == filter.price);
            //}
            if (filter.priceSort is true)
            {
                query = query.OrderBy(p => p.price);
            }

           return await query.Skip(filter.Skip).Take(filter.PageSize).ToListAsync();
        
        }


    }
}
