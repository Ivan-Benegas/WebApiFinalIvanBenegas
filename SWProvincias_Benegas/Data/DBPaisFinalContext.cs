using Microsoft.EntityFrameworkCore;
using SWProvincias_Benegas.Models;

namespace SWProvincias_Benegas.Data
{
    public class DBPaisFinalContext : DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }

    }
}
