using FluentValidation;
using Noob.D2CMSApi.Models.Requests;
using Noob.Validators;
namespace Noob.D2CMSApi.Models.Validators
{

    /// <summary>
    /// 用户信息表验证
    /// </summary>
    public class LoginRequestValidator : BaseValidator<LoginRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequestValidator"/> class.
        /// </summary>
        public LoginRequestValidator()
        {
            RuleFor(a => a.UserName).NotNull().NotEmpty().WithMessage("登录账号不能为空");
            RuleFor(a => a.Password).NotNull().NotEmpty().WithMessage("登录密码不能为空");
        }
    }

}
