using AudacesManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AudacesManagerAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        public ApiContext(DbContextOptions<ApiContext> opts) : base(opts)
        {

        }
    }
}