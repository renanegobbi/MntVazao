using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MntVazao.App.Models;

namespace MntVazao.App.Mappings
{
    internal class OrganizacaoConfiguration : IEntityTypeConfiguration<Organizacao>
    {
        public void Configure(EntityTypeBuilder<Organizacao> builder)
        {
            builder.HasKey("Organizacao_ID");

            builder
                .Property(o => o.Organizacao_Nome)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(o => o.Organizacao_Email)
                .HasColumnType("varchar(320)")
                .IsRequired();

            builder
                .Property(o => o.Organizacao_Tel)
                .HasColumnType("varchar(20)");

            builder
                .Property(o => o.Organizacao_Endereco)
                .HasColumnType("varchar(255)");

            // 1 : N => Organização: Sensores
            // Uma Organização tem muitos sensores
            builder.HasMany(o => o.Sensores)
                // Um sensor pertence a uma organização
                .WithOne(s => s.Organizacao)
                //Chave extrangeira na tabela Sensores é Organizacao_ID
                .HasForeignKey(s => s.Organizacao_ID);

            builder.ToTable("Organizacao");
        }
    }
}
