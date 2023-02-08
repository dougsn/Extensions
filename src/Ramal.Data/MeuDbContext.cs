using Microsoft.EntityFrameworkCore;
using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Setor> Setores{ get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Computador> Computadores  { get; set; }

        public DbSet<Impressora> Impressoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
