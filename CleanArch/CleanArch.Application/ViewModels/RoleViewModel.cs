namespace CleanArch.Application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Users = new List<string>();
        }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "نام نقش الزامی است")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "نام فارسی نقش الزامی است")]
        [Display(Name = " نام فارسی")]
        public string PersianName { get; set; }
        public List<string> Users { get; set; }
    }
}
