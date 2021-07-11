using ATS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data
{
    public class ATSDbContext : IdentityDbContext
    {
        public ATSDbContext(DbContextOptions<ATSDbContext> option) : base(option)
        {

        }
        public DbSet<Department> Department { set; get; }
        public DbSet<Audit> Audit { set; get; }
        public DbSet<Project> Project { set; get; }
        public DbSet<District> District { set; get; }
        public DbSet<Division> Division { set; get; }
        public DbSet<Upazila> Upazila { set; get; }       
        public DbSet<Objection> Objections { set; get; }
        public DbSet<UserDetails> UserDetails { set; get; }
        public DbSet<AuditUserMapping> AuditUserMapping { set; get; }
         
       
    }
}
