using FluentValidation;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS.ServiceLayer.FluentValidations
{
    public class ProjectValidator :AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(25)
                .WithName("Proje İsmi");
            RuleFor(x=>x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(200)
                .WithName("Proje Açıklaması");
            RuleFor(x => x.Budget)
                .GreaterThan(0)
                .WithName("Bütçe");
            RuleFor(x => x.ProjectManagerId)
                .NotEmpty()
                .WithName("Proje Yöneticisi");
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddDays(3))
                .WithName("Bitiş Tarihi");

        }
    }
}
