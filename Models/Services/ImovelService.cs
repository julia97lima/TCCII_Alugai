using Alugai.Data;
using Alugai.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alugai.Models.Services
{
    public class ImovelService
    {
        private readonly Repository<Imovel> _repoImovel;

        public ImovelService(ApplicationDbContext context)
        {
            _repoImovel = new Repository<Imovel>(context);
        }

        public List<Imovel> ListarImoveis(string cpf) 
        {
            return _repoImovel.Get()
                              .Where(x => x.AnuncianteCpf == cpf)
                              .Include(x => x.Endereco)
                              .ToList();
        }

        public async Task CriarImovel(Imovel novoImovel)
        {
            await _repoImovel.Insert(novoImovel);
        }

        public async Task RemoverImovel(int id)
        {
            var imovel = _repoImovel.Get()
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Endereco)
                                    .SingleOrDefault();

            await _repoImovel.Delete(imovel);
        }

        public async Task MudarStatusAnuncioImovel(int id, bool anunciar)
        {
            var imovel = _repoImovel.Get()
                                    .Where(x => x.Id == id)
                                    .SingleOrDefault();

            imovel.StatusImovel = anunciar;

            await _repoImovel.Update(imovel);
        }

        public Imovel? BuscarImovel(int id)
        {
            return _repoImovel.Get()
                              .Where(x => x.Id == id)
                              .Include(x => x.Endereco)
                              .SingleOrDefault();
        }

        public async Task AtualizarImovel(Imovel imovel)
        {
            var i = _repoImovel.Get().Where(x => x.Id == imovel.Id).SingleOrDefault();

            imovel.AnuncianteCpf = i.AnuncianteCpf;
            imovel.EnderecoId = i.EnderecoId;

            await _repoImovel.Update(imovel);
        }
    }
}
