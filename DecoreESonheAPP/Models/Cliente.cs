using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoreESonheAPP.Models
{
    public class Cliente
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
    }
}
