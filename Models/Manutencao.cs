using System;
using System.Collections.Generic;

namespace Alugai.Models
{
    public partial class Manutencao
    {
        public int Id { get; set; }
        public string TipoDeManutencao { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Valor { get; set; }
        public string ComodoImovel { get; set; } = null!;
        public int UsuarioId { get; set; }
        public int ImovelId { get; set; }
        public string StatusManutencao { get; set; } = null!;

        public virtual Imovel Imovel { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
