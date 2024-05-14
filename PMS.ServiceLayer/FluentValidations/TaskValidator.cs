using FluentValidation;
using PMS_EntityLayer.Concrete;

namespace PMS.ServiceLayer.FluentValidations
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.TaskName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Görev Adı");
        }
    }
}
