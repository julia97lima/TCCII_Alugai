using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Anuncio
    {
        public Anuncio()
        {
            Pagamentos = new HashSet<Pagamento>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal? PrecoFinal { get; set; }
        public DateTime Data { get; set; }
        public string? Status { get; set; }

        public int ImovelId { get; set; }
        public virtual Imovel Imovel { get; set; } = null!;

        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}
