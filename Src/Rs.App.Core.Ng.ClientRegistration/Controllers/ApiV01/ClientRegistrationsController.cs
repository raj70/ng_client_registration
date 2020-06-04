using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.ClientRegistration.Services;
using Rs.App.Core.Ng.ClientRegistration.ViewModel;

namespace Rs.App.Core.Ng.ClientRegistration.Controllers.ApiV01
{
    [Route("api/V01/[controller]")]
    [ApiController]
    public class ClientRegistrationsController : ControllerBase
    {
        private readonly IClientRegistrationService _clientRegistrationService;

        public ClientRegistrationsController(IClientRegistrationService clientRegistrationService)
        {
            _clientRegistrationService = clientRegistrationService;
        }

        public async Task<IActionResult> Post([FromBody] ClientViewModel clientRegitrationViewModel)
        {
            return Ok();
        }
    }
}
