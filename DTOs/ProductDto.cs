using Inventory_Management_System.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.DTOs
{
    public class Pager
    {
        public int PageSize { get; set; } = 5;
        public int PageNo { get; set; } = 1;
        public int Skip => PageSize * (PageNo - 1);

    }
    public class ProductDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
    public class ProductView : Pager
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal price { get; set; }
        public bool priceSort { get; set; }

    }
}
