using Org.BouncyCastle.Asn1.Ocsp;

namespace ProgramacaoIV.Venda.Api.Entidades;

public sealed class Transacao : AbstractEntity
{
    public Cliente Cliente { get; private set; }
    public Vendedor Vendedor { get; set; } // Propriedade não anulável
    public ICollection<ItemTransacao> Itens { get; private set; } = new List<ItemTransacao>();
    public decimal Total => Itens.Sum(x => x.Total);

    /// <summary>
    /// To EF Core
    /// </summary>
    private Transacao() : base() { }

    public Transacao(Cliente cliente) => Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));

    public Transacao(Cliente cliente, Vendedor vendedor)  // Construtor atualizado
    {
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Vendedor = vendedor ?? throw new ArgumentNullException(nameof(vendedor)); // Verificação de null
    }


    public void AdicionarItem(ItemTransacao item)
    {        
        Itens.Add(item);
        AtualizarDataAtualizacao();
    }

    public void RemoverItem(ItemTransacao item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        Itens.Remove(item);
        AtualizarDataAtualizacao();
    }
}