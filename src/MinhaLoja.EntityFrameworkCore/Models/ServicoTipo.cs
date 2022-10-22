using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [TableInfo(AreaName = "", SingleMetaName = "ServicoTipo", PluralMetaName = "ServicoTipos", Gender = "o", SingleName = "Tipo de Serviço", PluralName = "Tipos de Serviço")]
    public class ServicoTipo : Table
    {
        [DisplayName("Nome")]
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string Nome { get; set; } = default!;

        [DisplayName("Valor Padrão")]
        [Precision(14, 2)]
        public decimal ValorPadrao { get; set; }

        [DisplayName("Serviços")]
        public virtual ICollection<Servico> Servicos { get; set; }

        public ServicoTipo()
        {
            Servicos = new HashSet<Servico>();
        }
    }
}
