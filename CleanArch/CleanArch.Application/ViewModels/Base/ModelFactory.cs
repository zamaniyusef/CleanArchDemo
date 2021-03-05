namespace CleanArch.Application.ViewModels.Base
{
    using CleanArch.Domain.Auth;
    public class ModelFactory : IModelFactory
    {
        public ApplicationRole Create(RoleViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public RoleViewModel Create(ApplicationRole model)
        {
            return new RoleViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                PersianName = model.PersianName
            };
        }
    }
}
