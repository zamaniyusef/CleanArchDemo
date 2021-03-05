namespace CleanArch.Application.ViewModels.Base
{
    using CleanArch.Domain.Auth;
    public interface IModelFactory
    {
        ApplicationRole Create(RoleViewModel model);
        RoleViewModel Create(ApplicationRole model);
    }
}
