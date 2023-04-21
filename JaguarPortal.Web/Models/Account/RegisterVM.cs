using System.ComponentModel.DataAnnotations;

namespace JaguarPortal.Web.Models.Account
{
    public class RegisterVM
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        [Required]
        [MinLength(10)]
        public string Email { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Login { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }
        /// <summary>
        /// Confirm Password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [CustomValidation(typeof(ValidationPassword), "Validate")]
        public string ConfirmPassword { get; set; }
    }
    public class ValidationPassword
    {
        public static System.ComponentModel.DataAnnotations.ValidationResult Validate(object value, ValidationContext context)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (context is null)
                throw new ArgumentNullException(nameof(context));
            

            if (context.ObjectType == typeof(RegisterVM))
            {
                RegisterVM vm = (RegisterVM)context.ObjectInstance;

                if (vm.Password == vm.ConfirmPassword)
                    return ValidationResult.Success;
                else                
                    return new ValidationResult("Password and Confirm Password must be the same", new List<string>() { context.MemberName });                
            }
            return ValidationResult.Success;
        }
    }
}
