using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MntVazao.App.Models;

namespace MntVazao.App.Mappings
{
    internal class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey("Sensor_ID");

            builder
                .Property(s => s.Sensor_Descricao)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder
                .Property(s => s.Sensor_Ativo)
                .IsRequired();

            builder
                .Property(s => s.Sensor_Modelo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(s => s.Sensor_PressaoUnidade)
                .HasColumnType("varchar(50)");

            builder
                .Property(s => s.Sensor_VazaoUnidade)
                .HasColumnType("varchar(50)");

            builder
                .Property(s => s.Sensor_CodigoUPC)
                .HasColumnType("varchar(13)");

            builder
                .Property(s => s.Sensor_FabricantePartNumber)
                .HasColumnType("varchar(255)");

            // 1 : N => Sensor: Sensor_Localizacao
            // Um Sensor tem muitos Sensor_Localizacao
            builder.HasMany(s => s.SensorLocalizacao)
                // Um Sensor_Localizacao pertence a um Sensor
                .WithOne(sl => sl.Sensor)
                //Chave extrangeira na tabela Sensor_Localizacao é Organizacao_ID
                .HasForeignKey(sl => sl.Sensor_ID);

            builder.ToTable("Sensor");
        }
    }
}