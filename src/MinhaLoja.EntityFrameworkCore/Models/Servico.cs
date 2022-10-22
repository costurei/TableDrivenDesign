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
    [TableInfo(AreaName = "", SingleMetaName = "Servico", PluralMetaName = "Servicos", Gender = "o", SingleName = "Serviço", PluralName = "Serviços")]
    public class Servico : Table
    {
        [DisplayName("Tipo Id")]
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public virtual ServicoTipo Tipo { get; set; } = default!;

        [DisplayName("Descrição")]
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Descricao { get; set; } = default!;

        [DisplayName("Valor")]
        [Precision(14, 2)]
        public decimal Valor { get; set; }

        [DisplayName("Pedidos")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public Servico()
        {
            Pedidos = new HashSet<Pedido>();
        }
    }
}
