using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Behaviours;
using System.Reflection;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
           this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            return services;
        }
    }
}
