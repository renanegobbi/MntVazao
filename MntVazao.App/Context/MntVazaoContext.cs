using Microsoft.EntityFrameworkCore;
using MntVazao.App.Models;
using MntVazao.App.Mappings;

namespace MntVazao.App.Context
{
    public class MntVazaoContext : DbContext
    {
        public DbSet<Medicao> Medicao { get; set; }

        public DbSet<Organizacao> Organizacao { get; set; }

        public DbSet<Sensor> Sensor { get; set; }

        public DbSet<SensorLocalizacao> SensorLocalizacao { get; set; }


        public MntVazaoContext(DbContextOptions<MntVazaoContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Medicao>(new MedicaoConfiguration());
            modelBuilder.ApplyConfiguration<Organizacao>(new OrganizacaoConfiguration());
            modelBuilder.ApplyConfiguration<Sensor>(new SensorConfiguration());
            modelBuilder.ApplyConfiguration<SensorLocalizacao>(new SensorLocalizacaoConfiguration());
        }
    }
}
