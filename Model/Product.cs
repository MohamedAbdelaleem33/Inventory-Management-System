using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;


namespace Inventory_Management_System.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Description {  get; set; }
       
        public decimal price {  get; set; }

        public int StockQuantity {  get; set; }

        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        public  Category Category { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public  Supplier Supplier { get; set; }             

    }
}
