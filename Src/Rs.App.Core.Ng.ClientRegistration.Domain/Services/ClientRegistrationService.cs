﻿/** 
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
using Rs.App.Core.ClientRegistration.Exceptions;
using Rs.App.Core.ClientRegistration.Repository;
using Rs.App.Core.ClientRegistration.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Services
{
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

            if (existedClient != null)
            {
                throw new ClientExistException($"{client.ClientCredential.Username} already exist");
            }

            var addedClient = client;
            // check if the address exists
            var existedAddressQuery = await _addressRepository.FindAsync(x => x.CompareConcatenated == client.Address.CompareConcatenated);
            var existedAddress = await existedAddressQuery.FirstOrDefaultAsync();

            client.ClientCredential.HashPassword();
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
                addedClient = await _clientRepository.AddAsync(clientModel);
            }
            else
            {
                addedClient = await _clientRepository.AddAsync(clientModel);
                addedClient.Address = existedAddress; // just assign
            }
            await _clientRepository.SaveChangesAsync();

            return addedClient; // for now
        }       
    }
}
