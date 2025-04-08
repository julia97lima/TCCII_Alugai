using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alugai.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
        }
        [Key]
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<Imovel> Imoveis { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }

        //public virtual ICollection<Endereco> Enderecos { get; set; }
        //public virtual ICollection<Imovel> Imovels { get; set; }
        //public virtual ICollection<Manutencao> Manutencaos { get; set; }
    }
}
