using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaLoja.Models
{
    [EntityInfo(AreaName = "", SingleMetaName = "ServicoPrecoHistorico", PluralMetaName = "ServicoPrecoHistoricos", Gender = "o", SingleName = "Histórico de Preço de Serviço", PluralName = "Históricos de Preço de Serviço")]
    public class ServicoPrecoHistorico : Entity
    {
        [DisplayName("Serviço Id")]
        public int ServicoId { get; set; }

        [DisplayName("Servico")]
        public virtual Servico? Servico { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Valor (R$)")]
        [Precision(14, 2)]
        public decimal Valor { get; set; }

        [DisplayName("Duração")]
        public TimeSpan? Duracao { get => Data - Servico?.CreationDate; }

        public ServicoPrecoHistorico()
        {

        }
    }
}
