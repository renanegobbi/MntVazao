using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MntVazao.App.Models;

namespace MntVazao.App.Mappings
{
    internal class MedicaoConfiguration : IEntityTypeConfiguration<Medicao>
    {
        public void Configure(EntityTypeBuilder<Medicao> builder)
        {
            builder.HasKey("Sensor_ID", "Medicao_DataInicio");

            builder
                .Property(m => m.Medicao_DataFim)
                .IsRequired();

            builder
                .Property(m => m.Medicao_Leitura)
                .IsRequired();

            builder
                .Property(m => m.Medicao_Status)
                .IsRequired();
        }
    }

}
