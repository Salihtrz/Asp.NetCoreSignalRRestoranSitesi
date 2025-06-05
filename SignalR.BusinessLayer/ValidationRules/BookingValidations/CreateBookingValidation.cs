using FluentValidation;
using SignalR.DtoLayer.BookinkDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı goş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı goş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı goş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı goş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı goş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 karakter veri girişi yapınız!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 karakter veri girişi yapınız!");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz!");
        }
    }
}
