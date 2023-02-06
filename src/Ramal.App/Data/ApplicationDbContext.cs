using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ramal.App.ViewModels;
using Ramal.Business.Models;

namespace Ramal.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ramal.App.ViewModels.FuncionarioViewModel> FuncionarioViewModel { get; set; }
        public DbSet<Ramal.App.ViewModels.SetorViewModel> SetorViewModel { get; set; }
        public DbSet<Ramal.App.ViewModels.EmailViewModel> EmailViewModel { get; set; }
                
    }
}