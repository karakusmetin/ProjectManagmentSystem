using FluentValidation;
using PMS_EntityLayer.Concrete;
using System;

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
           
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithName("Göreve Atanan Kullanıcı");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(15)
                .MaximumLength(100)
                .WithName("Görev Açıklaması");

            RuleFor(x => x.StartDate)
               .LessThan(DateTime.Now.AddDays(30))
               .GreaterThan(DateTime.Now.AddDays(1))
               .NotEmpty()
               .WithName("Başlangıç Tarihi");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddDays(3))
                .WithName("Bitiş Tarihi");
        }
    }
}
