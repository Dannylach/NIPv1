using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using NIPv1.Entities;

namespace NIPv1.DAL
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext() : base("AuthDbContext") {}

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}