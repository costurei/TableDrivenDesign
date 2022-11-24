using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Models
{
    [EntityInfo(AreaName = "", SingleMetaName = "Servico", PluralMetaName = "Servicos", Gender = "o", SingleName = "Serviço", PluralName = "Serviços")]
    public class Servico : Entity
    {
        [DisplayName("Descrição")]
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Descricao { get; set; } = default!;

        [DisplayName("Preço (R$)")]
        [Precision(14, 2)]
        public decimal PrecoValor { get; set; }

        [DisplayName("Hist. Preço (#)")]
        public int? PrecoHistoricosTotalQuantidade { get => PrecoHistoricos?.Count; }

        [DisplayName("Históricos de Preço")]
        public virtual ICollection<ServicoPrecoHistorico>? PrecoHistoricos { get; set; }

        [DisplayName("Pedidos (#)")]
        public int? PedidosTotalQuantidade { get => Pedidos?.Count; }

        [DisplayName("Pedidos (R$)")]
        public decimal? PedidosTotalValor { get => Pedidos?.Sum(p => p.Valor); }

        [DisplayName("Pedidos")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public Servico()
        {
            PrecoHistoricos = new HashSet<ServicoPrecoHistorico>();

            Pedidos = new HashSet<Pedido>();
        }
    }
}
