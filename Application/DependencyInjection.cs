using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to register application-specific services.
        /// Adds MediatR services from the current assembly for handling CQRS patterns (commands, queries, events) 
        /// and FluentValidation for registering all validators from the current assembly.
        /// </summary>
        /// <param name="services">The IServiceCollection to which services are added.</param>
        /// <returns>The modified IServiceCollection with registered services.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {            
            var assembly = typeof(DependencyInjection).Assembly;            
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));
            
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
