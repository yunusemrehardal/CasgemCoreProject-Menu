using FluentValidation;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.BusinessLayer.ValidationRules.OurTeamValidator
{
    public class CreateOurTeamValidator:AbstractValidator<OurTeam>
    {
        public CreateOurTeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen minimum 3 karakter giriniz.");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen maksimum 30 karakter giriniz.");
        }
    }
}
