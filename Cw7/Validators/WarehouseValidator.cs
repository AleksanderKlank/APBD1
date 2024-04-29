using System.Data;
using Cw7.DTOs;
using FluentValidation;

namespace Cw7.Validators;

public class WarehouseValidator : AbstractValidator<CreateProductWarehouse>
{
    public WarehouseValidator()
    {
        RuleFor(w => w.Amount).NotNull().GreaterThan(0);
        RuleFor(w => w.CreatedAt).NotEmpty();
        RuleFor(w => w.IdWarehouse).NotNull();
        RuleFor(w => w.IdProduct).NotNull();
        
    }
   
    
}