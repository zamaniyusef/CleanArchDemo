namespace CleanArch.Infra.IoC
{
    using CleanArc.LoggerService;
    using CleanArch.Application;
    using CleanArch.Application.ViewModels.Base;
    using Microsoft.Extensions.DependencyInjection;
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IModelFactory, ModelFactory>();
        }
    }
}
