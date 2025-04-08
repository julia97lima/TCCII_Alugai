using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Despesa
    {
        public int Id { get; set; }
        public string TipoDeDespesa { get; set; } = null!;
        public decimal Valor { get; set; }
        public string DescricaoDespesa { get; set; } = null!;
        public int ImovelId { get; set; }

        public virtual Imovel Imovel { get; set; } = null!;
    }
}
