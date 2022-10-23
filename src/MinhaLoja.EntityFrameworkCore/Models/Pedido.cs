using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [EntityInfo(AreaName = "", SingleMetaName = "Pedido", PluralMetaName = "Pedidos", Gender = "o", SingleName = "Pedido", PluralName = "Pedidos")]
    public class Pedido : Entity
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

        [DisplayName("Previsão Entrega")]
        public DateTime EntregaPrevisaoData { get; set; }

        [DisplayName("Data Entrega")]
        public DateTime? EntregaData { get; set; }

        [DisplayName("Valor (R$)")]
        [Precision(14, 2)]
        public decimal Valor { get; set; }

        [DisplayName("Sinal (R$)")]
        [Precision(14, 2)]
        public decimal SinalValor { get; set; }

        [DisplayName("Pago")]
        public bool Pago { get; set; }

        [DisplayName("Hist. Prev. Entrega (#)")]
        public int? EntregaPrevisaoHistoricosTotalQuantidade { get => EntregaPrevisaoHistoricos?.Count; }

        [DisplayName("Históricos Previsão Entrega")]
        public virtual ICollection<PedidoEntregaPrevisaoHistorico>? EntregaPrevisaoHistoricos { get; set; }

        public Pedido()
        {

        }
    }
}
