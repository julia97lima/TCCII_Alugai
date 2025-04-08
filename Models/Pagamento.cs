using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Pagamento
    {
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string FormaDePagamento { get; set; } = null!;
        
        public int AnuncioId { get; set; }
        public virtual Anuncio Anuncio { get; set; } = null!;
    }
}
