/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 4:31:01 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Domain
{
    public class ClientCredential : AbstractDomain
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}

