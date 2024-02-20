﻿using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration) {


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("RENVES"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    );
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            
        }
    }
}
