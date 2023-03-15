using ApplicationCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class MotorcycleDataContext : DbContext
    {
        public MotorcycleDataContext(DbContextOptions<MotorcycleDataContext> options) : base(options)
        {

        }
        public DbSet<Motorcycle> Motorcycles { get; set; }
    }
}
