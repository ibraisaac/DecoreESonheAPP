using DecoreESonheAPP.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoreESonheAPP.Models
{
    public class Pedido
    {
        public int Identificador { get; set; }
        public int Codigo { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DateTime? DataPagamento { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
        public TipoEntrega? TipoEntrega { get; set; }
        public CanalVenda? CanalVenda { get; set; }
        public Status Status { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
        public string Observacao { get; set; }
    }
}
