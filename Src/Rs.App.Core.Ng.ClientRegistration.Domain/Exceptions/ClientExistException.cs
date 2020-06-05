/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/5/2020 11:35:48 AM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Exceptions
{
    [Serializable]
    public class ClientExistException : Exception
    {
        public ClientExistException() { }
        public ClientExistException(string message) : base(message) { }
        public ClientExistException(string message, Exception inner) : base(message, inner) { }
        protected ClientExistException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

