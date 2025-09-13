using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Model;
using Inventory_Management_System.Unit;
using Microsoft.AspNetCore.Mvc;
using Inventory_Management_System.DTOs;
using FluentValidation;


namespace Inventory_Management_System.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDto> _validator;
        public ProductController(IUnitOfWork  unitOfWork,IMapper mapper,IValidator<ProductDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductView p)
        {
            var res = await _unitOfWork.ProductRepo.GetFilteredProducts(p);
            var resDto = _mapper.Map<IEnumerable<ProductDto>>(res);
            //return Ok(resDto);
            return Ok(new
            {
                Data = resDto,
                Pagination = new
                {
                    p.PageNo,
                    p.PageSize
                }
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductWithId(int id)
        {
            var res = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto p)
        {
            var ValRes = await _validator.ValidateAsync(p);
            if (!ValRes.IsValid) 
            {
                var err = ValRes.Errors;
                return BadRequest(err);
            }
            var input = _mapper.Map<Product>(p);
            await _unitOfWork.ProductRepo.AddAsync(input);
            await _unitOfWork.SaveChangesAsync();
            return NoContent(); 
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductDto p)
        {
            var r = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (r != null)
            {
                r.Name = p.Name;
                r.price = p.price;
                r.SupplierId = p.SupplierId;    
                r.StockQuantity = p.StockQuantity;
                r.CategoryId = p.CategoryId;    
                r.Description = p.Description;
                await _unitOfWork.ProductRepo.UpdateAsync(r);
                await _unitOfWork.SaveChangesAsync(); 
                return NoContent();
            }
            else return BadRequest($"No Product With Id {id}");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var r = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (r != null)
            {
                await _unitOfWork.ProductRepo.DeleteAsync(r);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            else return BadRequest($"No Product With Id {id}");
        }
    }
}
