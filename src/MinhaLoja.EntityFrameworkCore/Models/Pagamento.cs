using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MinhaLoja.Models
{
    [TableInfo(AreaName = "", SingleMetaName = "Pagamento", PluralMetaName = "Pagamentos", Gender = "o", SingleName = "Pagamento", PluralName = "Pagamentos")]
    public class Pagamento : Table
    {
        [DisplayName("Pedido Id")]
        public int PedidoId { get; set; }

        [DisplayName("Pedido")]
        public virtual Pedido Pedido { get; set; } = default!;

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Valor")]
        [Precision(14, 2)]
        public decimal Valor { get; set; }
    }
}
