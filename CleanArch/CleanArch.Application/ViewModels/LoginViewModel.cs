namespace CleanArch.Application.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required(ErrorMessage = "موبایل الزامی است")]
        [Display(Name = "موبایل")]
        [Phone]
        public string Mobile { get; set; }
        [Display(Name = "کلمه‌عبور")]
        [Required(ErrorMessage = "کلمه‌عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به‌خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
