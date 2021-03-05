namespace CleanArch.Domain.Auth
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string PersianName { get; set; }
    }
}
