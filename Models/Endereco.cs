using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            //Imovels = new HashSet<Imovel>();
        }

        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public int Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string EstadoUf { get; set; } = null!;

        //public virtual Usuario Usuario { get; set; } = null!;
        //public virtual ICollection<Imovel> Imovels { get; set; }
    }
}
