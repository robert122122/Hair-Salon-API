
using FluentValidation;

namespace Hair_Salon_API.Models
{
    public class UserPostDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Image { get; set; }
    }

    public class UserValidator : AbstractValidator<UserPostDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}
