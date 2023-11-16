using Core.ViewModels;
using FluentValidation;

namespace Core.Validators
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {

        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is mandatory");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is mandatory");
            RuleFor(x => x.FirstName).Length(5, 50).WithMessage("First Name should be between 5 characters and 15 chracters");
        }

    }
}
