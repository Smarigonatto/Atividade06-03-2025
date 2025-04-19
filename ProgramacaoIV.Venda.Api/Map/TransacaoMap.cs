using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramacaoIV.Venda.Api.Entidades;

namespace ProgramacaoIV.Venda.Api.Map;

public sealed class TransacaoMap : AbstractEntidadeMap<Transacao>
{
    public override void Configure(EntityTypeBuilder<Transacao> builder)
    {
        base.Configure(builder);

        builder.ToTable("TRANSACAO");

        builder
            .HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey("ID_CLIENTE")
            .OnDelete(DeleteBehavior.Restrict) // Evita deleção em cascata
            .IsRequired();

        // Adiciona o relacionamento com Vendedor
        builder
            .HasOne(x => x.Vendedor)
            .WithMany() // Se a entidade Vendedor possuir uma coleção de transações, pode ser usado: .WithMany(v => v.Transacoes)
            .HasForeignKey("ID_VENDEDOR")
            .OnDelete(DeleteBehavior.Restrict) // Garante integridade referencial sem deleção em cascata
            .IsRequired();

        builder.HasMany(x => x.Itens)
            .WithOne()
            .HasForeignKey("ID_TRANSACAO")
            .OnDelete(DeleteBehavior.Cascade); // Exclui itens associados quando a transação é removida

        builder.Ignore(x => x.Total);
    }
}
