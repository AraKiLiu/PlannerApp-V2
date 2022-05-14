using FluentValidation;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Vailidators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{

    public RegisterRequestValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("請輸入電子郵件")
            .EmailAddress()
            .WithMessage("不是有效的電子郵件地址");

        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("請輸入姓氏")
            .MaximumLength(25)
            .WithMessage("姓氏長度最大25個字");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("請輸入名字")
            .MaximumLength(25)
            .WithMessage("名字長度最大25個字");

        RuleFor(p => p.Password)
            .NotEmpty()
            .WithMessage("請輸入密碼")
            .MinimumLength(5)
            .WithMessage("密碼長度不可小於6個字");

        RuleFor(p => p.ConfirmPassword)
            .Equal(p => p.Password)
            .WithMessage("密碼與前次並不符合"); 
                
    }

}