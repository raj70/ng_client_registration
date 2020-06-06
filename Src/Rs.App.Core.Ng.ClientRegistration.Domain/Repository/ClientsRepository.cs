/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 8:04:13 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.ClientRegistration.Data;
using Rs.App.Core.ClientRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Repository
{
    public class ClientsRepository : AbstractRepository<Client>
    {
        public ClientsRepository(ApplicationDbContext context) : base(context)
        {

        }

        private ApplicationDbContext DBContext
        {
            get
            {
                return (_dbContext as ApplicationDbContext);
            }
        }

        public async override Task<IQueryable<Client>> GetAllAsync()
        {
            return await Task.Run(() => DBContext.Clients.Include(x => x.ClientCredential));            
        }
    }
}

