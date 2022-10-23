using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [EntityInfo(AreaName = "", SingleMetaName = "PedidoEntregaPrevisaoHistorico", PluralMetaName = "PedidoEntregaPrevisaoHistoricos", Gender = "o", SingleName = "Histórico de Previsão de Entrega de Pedido", PluralName = "Históricos de Previsão de Entrega de Pedido")]
    public class PedidoEntregaPrevisaoHistorico : Entity
    {
        [DisplayName("Pedido Id")]
        public int PedidoId { get; set; }

        [DisplayName("Pedido")]
        public virtual Pedido Pedido { get; set; } = default!;

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        public PedidoEntregaPrevisaoHistorico()
        {

        }
    }
}
