namespace CleanArch.Application.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterViewModel
    {
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "موبایل الزامی است")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه‌عبور")]
        [Required(ErrorMessage = "کلمه‌عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه‌عبور")]
        [Required(ErrorMessage = "تکرار کلمه‌عبور الزامی است")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه‌عبور و تکرار آن یکسان نیست")]
        public string ConfirmPassword { get; set; }
    }
}
