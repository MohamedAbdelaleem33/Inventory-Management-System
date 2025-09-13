
using FluentValidation;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Model;

namespace Inventory_Management_System.Validation
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Fluent Validation: Name is Required")
                .MaximumLength(50);
        }
        
    }
}
