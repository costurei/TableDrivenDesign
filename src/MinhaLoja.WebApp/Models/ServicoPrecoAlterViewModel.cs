using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MinhaLoja.Models
{
    public class ServicoPrecoAlterViewModel
    {
        public int ServicoId { get; set; }

        [Timestamp]
        public byte[] ServicoRowVersion { get; set; } = default!;

        [DisplayName("Descrição")]
        public string? ServicoDescricao { get; set; }

        [DisplayName("Preço (R$)")]
        [Precision(14, 2)]
        public decimal ServicoPrecoValor { get; set; }
        
        [DisplayName("Data")]
        public DateTime Data { get; set; }
    }
}
