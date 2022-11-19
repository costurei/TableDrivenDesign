using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [EntityInfo(AreaName = "", SingleMetaName = "Cliente", PluralMetaName = "Clientes", Gender = "o", SingleName = "Cliente", PluralName = "Clientes")]
    public class Cliente : Entity
    {
        [DisplayName("Nome")]
        public string Nome { get => $"{(NomePrefixo == null ? "" : $"{NomePrefixo} ")}{NomePrimeiro}, {NomeSufixo}"; }

        [DisplayName("Prefixo Nome")]
        [StringLength(64, MinimumLength = 2)]
        public string? NomePrefixo { get; set; }

        [DisplayName("Primeiro Nome")]
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string NomePrimeiro { get; set; } = default!;

        [DisplayName("Segundo Nome")]
        [StringLength(64, MinimumLength = 2)]
        public string? NomeSegundo { get; set; }

        [DisplayName("Sufixo Nome")]
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string NomeSufixo { get; set; } = default!;

        [DisplayName("Telefone")]
        [StringLength(16, MinimumLength = 8)]
        public string? Telefone { get; set; }

        [DisplayName("Endereço")]
        [StringLength(256, MinimumLength = 8)]
        public string? Endereco { get; set; }

        [DisplayName("Pedidos (#)")]
        public int? PedidosTotalQuantidade { get => Pedidos?.Count; }

        [DisplayName("Pedidos (R$)")]
        public decimal? PedidosTotalValor { get => Pedidos?.Sum(p => p.Valor); }

        [DisplayName("Pedidos")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }
    }
}
