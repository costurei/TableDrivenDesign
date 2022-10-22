using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [TableInfo(AreaName = "", SingleMetaName = "Cliente", PluralMetaName = "Clientes", Gender = "o", SingleName = "Cliente", PluralName = "Clientes")]
    public class Cliente : Table
    {
        [DisplayName("Nome")]
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Nome { get; set; } = default!;

        [DisplayName("Referência")]
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Referencia { get; set; } = default!;

        [DisplayName("Telefone")]
        [StringLength(16, MinimumLength = 8)]
        public string? Telefone { get; set; }

        [DisplayName("Endereço")]
        [StringLength(256, MinimumLength = 8)]
        public string? Endereco { get; set; }

        [DisplayName("Pedidos (#)")]
        public int? PedidosQuantidade { get => Pedidos?.Count; }

        [DisplayName("Pedidos (R$)")]
        public decimal? PedidosTotal { get => Pedidos?.Sum(p => p.Valor); }

        [DisplayName("Pedidos")]
        public virtual ICollection<Pedido>? Pedidos { get; set; }

        [DisplayName("Pagamentos (#)")]
        public int? PagamentosQuantidade { get => Pedidos?.Sum(p => p.Pagamentos?.Count); }

        [DisplayName("Pagamentos (R$)")]
        public decimal? PagamentosTotal { get => Pedidos?.Sum(p => p.Pagamentos?.Sum(p => p.Valor)); }

        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }
    }
}
