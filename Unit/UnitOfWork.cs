using Inventory_Management_System.Model;
using Inventory_Management_System.Repository.CategoryRepo;
using Inventory_Management_System.Repository.GenericRepo;
using Inventory_Management_System.Repository.ProductRepo;
using Inventory_Management_System.Repository.SupplierRepo;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepo _productRepo;
        private CategoryRepo _categoryRepo;
        private SupplierRepo _supplierRepo;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public ProductRepo ProductRepo => _productRepo ?? new ProductRepo(_context);
        public CategoryRepo CategoryRepo => _categoryRepo ?? new CategoryRepo(_context);
        public SupplierRepo SupplierRepo => _supplierRepo ?? new SupplierRepo(_context);
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose() { }
    }
}
