using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.Venda.Api.Map;

namespace ProgramacaoIV.Venda.Api.Entidades.Mappings
{
    public class VendedorMap : AbstractEntidadeMap<Vendedor>
    {
        public override void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            // Define o nome da tabela

            base.Configure(builder);

            builder.ToTable("VENDEDOR");

            // Propriedade Nome
            builder.Property(v => v.Nome)
                   .HasColumnName("NN_VENDEDOR")
                   .IsRequired()
                   .HasMaxLength(100);

            // Propriedade Email
            builder.Property(v => v.Email)
                   .HasColumnName("DS_EMAIL")
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}

// Essa configuração garante que o mapeamento do Vendedor esteja de acordo com as regras estabelecidas.