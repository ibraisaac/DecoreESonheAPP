using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoreESonheAPP.Models
{
    public class Produto
    {
        public int Identificador { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
