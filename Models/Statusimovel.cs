using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Statusimovel
    {
        public Statusimovel()
        {
            Imovels = new HashSet<Imovel>();
        }

        public int CodigoStatusImovel { get; set; }
        public string StatusImovel1 { get; set; } = null!;

        public virtual ICollection<Imovel> Imovels { get; set; }
    }
}
