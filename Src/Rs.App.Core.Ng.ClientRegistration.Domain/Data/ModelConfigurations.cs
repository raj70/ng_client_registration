/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 4:47:55 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rs.App.Core.ClientRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Data
{
    public class ClientModelConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.Property<DateTime>(nameof(Client.Dob)).IsRequired(true).HasColumnName("DateOfBirth");
            builder.Property<string>(nameof(Client.FirstName)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(Client.LastName)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(Client.PhoneNumber)).IsRequired(true).HasMaxLength(30);
        }
    }

    public class AddressModelConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.Property<string>(nameof(Address.Line1)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(Address.Line2)).HasMaxLength(250);
            builder.Property<string>(nameof(Address.Line3)).HasMaxLength(250);
            builder.Property<string>(nameof(Address.CompareConcatenated)).HasMaxLength(250 * 6 + 1);
            builder.Property<string>(nameof(Address.Suburb)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(Address.Postcode)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(Address.Country)).IsRequired(true).HasMaxLength(250);
        }
    }

    public class CredentialModelConfigurations : IEntityTypeConfiguration<ClientCredential>
    {
        public void Configure(EntityTypeBuilder<ClientCredential> builder)
        {
            builder.ToTable("Credentials");
            builder.Property<string>(nameof(ClientCredential.Username)).IsRequired(true).HasMaxLength(250);
            builder.Property<string>(nameof(ClientCredential.Username)).IsRequired(true).HasMaxLength(250);
        }
    }
}

