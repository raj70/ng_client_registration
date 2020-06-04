/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 4:30:08 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Domain
{
    public class Address : AbstractDomain
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        private string _compareConcatenated;
        public string CompareConcatenated
        {
            get
            {
                return _compareConcatenated;
            }
            set
            {
                _compareConcatenated = $"{Line1}{Line2}{Line3}{Suburb}{Postcode}{Country}";
            }
        }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

    }
}

