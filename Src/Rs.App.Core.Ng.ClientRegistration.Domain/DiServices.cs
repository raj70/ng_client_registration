/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 7:08:08 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.ClientRegistration.Data;
using Rs.App.Core.ClientRegistration.Domain;
using Rs.App.Core.ClientRegistration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Ng.ClientRegistration
{
    public static class ClientRegDiServices
    {
        public static IServiceCollection AddClientDbContext(this IServiceCollection services, 
            string connectionString)
        {
            return services
                .AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(true));
        }

        public static IServiceCollection AddClientAppDi(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Client>, ClientsRepository>();
            services.AddScoped<IRepository<Address>, AddressesRepository>();
            services.AddScoped<IRepository<ClientCredential>, CredentialsRepository>();
            return services;
        }
    }
}

