using AutoMapper;
using Inventory_Management_System.Model;
using Inventory_Management_System.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/[Controller]")] 
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _unitOfWork.CategoryRepo.GetAllAsync();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category c)
        {
            await _unitOfWork.CategoryRepo.AddAsync(c);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category c)
        {
            var r = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (r == null) return BadRequest($"Id {id} is not found");
            else
            {
                r.Name = c.Name;
                r.Description = c.Description;
                _unitOfWork.CategoryRepo.UpdateAsync(r);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var r = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (r == null) return BadRequest($"Id {id} is not found");
            else
            {
                await _unitOfWork.CategoryRepo.DeleteAsync(r);
                await _unitOfWork.SaveChangesAsync();
                return Ok($"Category with id {id} is deleted successfully");
            }
        }

    }
}
