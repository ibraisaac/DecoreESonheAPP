using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoreESonheAPP.Models
{
    public class PedidoItem
    {
        public int Identificador { get; set; }
        public int Codigo { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}
