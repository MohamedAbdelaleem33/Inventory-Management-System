using AutoMapper;
using Inventory_Management_System.Model;
using Inventory_Management_System.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;      
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _unitOfWork.SupplierRepo.GetAllAsync();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier c)
        {
            await _unitOfWork.SupplierRepo.AddAsync(c);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] Supplier c)
        {
            var r = await _unitOfWork.SupplierRepo.GetByIdAsync(id);
            if (r == null) return BadRequest($"Id {id} is not found");
            else
            {
                r.Name = c.Name;
                r.Email = c.Email;
                r.Phone = c.Phone;
                _unitOfWork.SupplierRepo.UpdateAsync(r);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var r = await _unitOfWork.SupplierRepo.GetByIdAsync(id);
            if (r == null) return BadRequest($"Id {id} is not found");
            else
            {
                await _unitOfWork.SupplierRepo.DeleteAsync(r);
                await _unitOfWork.SaveChangesAsync();
                return Ok($"Supplier with id {id} is deleted successfully");
            }
        }
    }
}
