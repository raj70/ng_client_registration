using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.ClientRegistration.Domain;
using Rs.App.Core.ClientRegistration.Exceptions;
using Rs.App.Core.ClientRegistration.Repository;
using Rs.App.Core.ClientRegistration.Services;
using Rs.App.Core.Ng.ClientRegistration.ViewModel;

namespace Rs.App.Core.Ng.ClientRegistration.Controllers.ApiV01
{
    [Route("api/V01/[controller]")]
    [ApiController]
    public class ClientRegistrationsController : ControllerBase
    {
        private readonly IClientRegistrationService _clientRegistrationService;
        private readonly IRepository<Client> _clientRepository;

        public ClientRegistrationsController(IRepository<Client> clientRepository, IClientRegistrationService clientRegistrationService)
        {
            _clientRegistrationService = clientRegistrationService;
            _clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientViewModel clientRegitrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error in user data");
            }
            try
            {
                var client = await _clientRegistrationService.AddAsync(clientRegitrationViewModel.Client());
                return Ok(client.CreateVm());
            }
            catch(ClientExistException ex)
            {
                ModelState.AddModelError(nameof(ClientViewModel.EmailAddress), ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            var list = new List<ClientViewModel>();
            await clients.ForEachAsync(x => list.Add(x.CreateVm(false)));

            return Ok(list);
        }
    }
}
