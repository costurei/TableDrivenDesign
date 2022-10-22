using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [TableInfo(AreaName = "", SingleMetaName = "Pedido", PluralMetaName = "Pedidos", Gender = "o", SingleName = "Pedido", PluralName = "Pedidos")]
    public class Pedido : Table
    {
        [DisplayName("Cliente Id")]
        public int ClienteId { get; set; }

        [DisplayName("Cliente")]
        public virtual Cliente Cliente { get; set; } = default!;

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Serviço Id")]
        public int ServicoId { get; set; }

        [DisplayName("Serviço")]
        public virtual Servico Servico { get; set; } = default!;

        [DisplayName("Descrição")]
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Descricao { get; set; } = default!;

        [DisplayName("Valor")]
        [Precision(14, 2)]
        public decimal Valor { get; set; }

        [DisplayName("Pagamentos (#)")]
        public int? PagamentosQuantidade { get => Pagamentos?.Count; }

        [DisplayName("Pagamentos (R$)")]
        public decimal? PagamentosTotal { get => Pagamentos?.Sum(p => p.Valor); }

        [DisplayName("Pagamentos")]
        public virtual ICollection<Pagamento> Pagamentos { get; set; }

        public Pedido()
        {
            Pagamentos = new HashSet<Pagamento>();
        }
    }
}
