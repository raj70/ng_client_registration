/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 8:17:23 PM
* 
* [4.0.30319.42000]
*/
using Rs.App.Core.ClientRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Services
{
    public interface IClientRegistrationService
    {
        Task<Client> AddAsync(Client client);
    }
}
