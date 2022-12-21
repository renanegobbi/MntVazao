using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MntVazao.App.Models;

namespace MntVazao.App.Mappings
{
    internal class SensorLocalizacaoConfiguration : IEntityTypeConfiguration<SensorLocalizacao>
    {
        public void Configure(EntityTypeBuilder<SensorLocalizacao> builder)
        {
            builder.HasKey("Sensor_ID");

            builder
                .Property(sl => sl.Sensor_Localizacao_Descr)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.ToTable("Sensor_Localizacao");
        }
    }
}
