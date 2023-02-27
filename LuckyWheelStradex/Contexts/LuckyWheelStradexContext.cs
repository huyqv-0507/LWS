using LuckyWheelStradex.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyWheelStradex.Contexts
{
    public class LuckyWheelStradexContext : DbContext
    {
        public LuckyWheelStradexContext(DbContextOptions<LuckyWheelStradexContext> opt) : base(opt) { }
        
        public DbSet<Player>? Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().Property(_ => _.Id).ValueGeneratedOnAdd();
        }
    }
}
