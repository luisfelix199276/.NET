using Store.Core.Repository.Interface.UoW;
using FluentValidation;
using Store.Core.Entity.Entities;

namespace Store.Core.Service.Validator.Customers
{
    public class CustomerValidator : AbstractValidator<Entity.Entities.Customers>
    {
        private readonly IUnitOfWork _uow;

       
        public CustomerValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.CPF).NotEmpty().Length(11).WithMessage("CPF deve ter 11 caracteres.");
            RuleFor(x => x.Name).NotEmpty().Length(0, 100).WithName("Nome");
        }
    }
}
