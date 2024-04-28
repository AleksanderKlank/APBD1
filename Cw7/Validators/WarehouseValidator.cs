using System.Data;
using Cw7.DTOs;
using FluentValidation;

namespace Cw7.Validators;

public class WarehouseValidator : AbstractValidator<CreateProductWarehouse>
{
    public WarehouseValidator()
    {
        RuleFor(w => w.Amount).GreaterThan(0).NotNull();
        RuleFor(w => w.CreatedAt).NotEmpty();
    }
   
    
}