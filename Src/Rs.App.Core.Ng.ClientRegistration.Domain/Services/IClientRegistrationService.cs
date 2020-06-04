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
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.ClientRegistration.Domain;
using Rs.App.Core.ClientRegistration.Repository;
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

    public class ClientRegistrationService : IClientRegistrationService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<ClientCredential> _credentialRepository;

        public ClientRegistrationService(IRepository<Client> clientRepository,
            IRepository<Address> addressReposirtory,
            IRepository<ClientCredential> credentialRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressReposirtory;
            _credentialRepository = credentialRepository;
        }
        public async Task<Client> AddAsync(Client client)
        {
            // find if user exists
            var existedQuery = await _credentialRepository.FindAsync(x => x.Username == client.ClientCredential.Username);
            var existedClient = await existedQuery.FirstOrDefaultAsync();

            // dummy hold;
            var addedClient = client;
            if (existedClient == null)
            { 
                // check if the address exists
                var existedAddressQuery = await _addressRepository.FindAsync(x => x.CompareConcatenated == client.Address.CompareConcatenated);
                var existedAddress = await existedAddressQuery.FirstOrDefaultAsync();

                var clientModel = new Client
                {
                    Dob = client.Dob,
                    FirstName = client.FirstName,
                    IsActive = client.IsActive,
                    LastName = client.LastName,
                    PhoneNumber = client.PhoneNumber,
                    ClientCredential = client.ClientCredential
                };
                if (existedAddress == null)
                {
                    // if not add address
                    clientModel.Address = client.Address; // added
                    addedClient = await _clientRepository.AddAsync(client);
                }
                else
                {
                    addedClient = await _clientRepository.AddAsync(client);
                    // if not add
                    clientModel.Address = client.Address; // just assign
                }
                await _clientRepository.SaveChangesAsync();

            }
            return addedClient; // for now
        }
    }
}
