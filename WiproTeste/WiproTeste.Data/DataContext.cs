using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities;

namespace WiproTeste.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Locacoes> Locacoes { get; set; }
    }
}
