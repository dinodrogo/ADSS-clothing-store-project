using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingStoreProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClothingStoreProject.Data
{
    public class ClothingStoreProjectContext : IdentityDbContext
    {
        public ClothingStoreProjectContext (DbContextOptions<ClothingStoreProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ClothingStoreProject.Models.Clothes> Clothes { get; set; }

        public DbSet<ClothingStoreProject.Models.UserInfo> UserInfo { get; set; }

    }
}
