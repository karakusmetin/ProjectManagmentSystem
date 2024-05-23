using FluentValidation;
using PMS_EntityLayer.Concrete;


namespace PMS.ServiceLayer.FluentValidations
{
    public class UserValidator :AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x=>x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25)
                .WithName("İsim");
            
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25)
                .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .WithName("Telefon numarası");
        }
    }
}
