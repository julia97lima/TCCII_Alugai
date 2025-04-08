using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Alugai.Models
{
    public partial class Imovel
    {
        public Imovel()
        {
            //Anuncios = new HashSet<Anuncio>();
            //Despesas = new HashSet<Despesa>();
            //Manutencaos = new HashSet<Manutencao>();
        }

        public int Id { get; set; }
        public TipoImovel TipoImovel { get; set; }
        public int QuantidadeDeQuartos { get; set; }
        public int QuantidadeDeBanheiros { get; set; }
        public int? QuantidadeDeSuites { get; set; }
        public float AreaQuadrada { get; set; }
        public int? QuantidadeDeAndares { get; set; }
        public int? QuantidadeDeGaragem { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal ValorDoAluguel { get; set; }
        public decimal? ValorDoCondominio { get; set; }
        public decimal? ValorDoIptu { get; set; }
        public int QuantidadeCozinha { get; set; }
        public int QuantidadeDeSala { get; set; }
        public bool StatusImovel { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; } = null!;

        public string AnuncianteCpf { get; set; }
        public virtual Usuario Anunciante { get; set; } = null!;

        //public virtual Anuncio Anuncio { get; set; }
        //public virtual Statusimovel StatusImovelNavigation { get; set; } = null!;
        //public virtual ICollection<Despesa> Despesas { get; set; }
        //public virtual ICollection<Manutencao> Manutencaos { get; set; }
    }

    public enum TipoImovel 
    {
        [Description("Casa")]
        Casa,
        [Description("Apartamento")]
        Apartamento,
        [Description("Kitnet")]
        Kitnet
    }

}
