using System.ComponentModel;

namespace MinhaLoja.Models
{
    public class PedidosEncomendarViewModel
    {
        [DisplayName("Cliente Id")]
        public int ClienteId { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        public PedidoServicoEncomendarViewModel[] Servicos { get; set; } = null!;
    }

    public class PedidoServicoEncomendarViewModel
    {
        [DisplayName("Selecionado")]
        public bool Selecionado { get; set; }

        [DisplayName("Serviço Id")]
        public int ServicoId { get; set; }

        [DisplayName("Serviço")]
        public string ServicoDescricao { get; set; } = null!;

        [DisplayName("Descrição")]
        public string Descricao { get; set; } = default!;

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [DisplayName("Valor (R$)")]
        public decimal Valor { get; set; }

        [DisplayName("Previsão Entrega")]
        public DateTime EntregaPrevisaoData { get; set; }

        [DisplayName("Sinal (R$)")]
        public decimal SinalValor { get; set; }

        [DisplayName("Pago")]
        public bool Pago { get; set; }
    }
}
