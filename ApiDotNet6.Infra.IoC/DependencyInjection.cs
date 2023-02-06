using System;
using ApiDotNet6.Application.Mappings;
using ApiDotNet6.Application.Services;
using ApiDotNet6.Application.Services.Interfaces;
using ApiDotNet6.Domain.Repositories;
using ApiDotNet6.infra.Data.Context;
using ApiDotNet6.infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDotNet6.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(DomainToDtoMapping));
			services.AddScoped<IPersonService, PersonService>();

			return services;
		}
	}
}

