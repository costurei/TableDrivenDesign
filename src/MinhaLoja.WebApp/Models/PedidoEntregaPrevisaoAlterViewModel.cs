﻿using System.ComponentModel;

namespace MinhaLoja.Models
{
    public class PedidoEntregaPrevisaoAlterViewModel : EntityViewModel
    {
        [DisplayName("Cliente Id")]
        public int ClienteId { get; set; }

        [DisplayName("Cliente")]
        public string ClienteNome { get; set; } = null!;

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Serviço Id")]
        public int ServicoId { get; set; }

        [DisplayName("Serviço")]
        public string ServicoDescricao { get; set; } = null!;

        [DisplayName("Descrição")]
        public string Descricao { get; set; } = default!;

        [DisplayName("Nova Previsão Entrega")]
        public DateTime EntregaPrevisaoDataNova { get; set; }

        [DisplayName("Data Entrega")]
        public DateTime? EntregaData { get; set; }

        [DisplayName("Valor (R$)")]
        public decimal Valor { get; set; }

        [DisplayName("Sinal (R$)")]
        public decimal SinalValor { get; set; }

        [DisplayName("Pago")]
        public bool Pago { get; set; }

        [DisplayName("Hist. Prev. Entrega (#)")]
        public int? EntregaPrevisaoHistoricosTotalQuantidade { get; set; }
    }
}