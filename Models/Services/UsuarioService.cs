using Alugai.Data;
using Alugai.Models.Repositories;
namespace Alugai.Models.Services
{
    public class UsuarioService
    {
        private readonly Repository<Usuario> _usuarioRepositorio;
        //criação do serviço de usuario
        public UsuarioService(ApplicationDbContext context)
        {
            _usuarioRepositorio = new Repository<Usuario>(context); 
        }

        public Usuario PegarUsuario(string cpf)
        {
            return _usuarioRepositorio.Get(x => x.Cpf.Equals(cpf)).SingleOrDefault();
        }

        public List<Usuario> ListarTodos()
        {
            return _usuarioRepositorio.Get().ToList();
        }

        public async Task Criar(Usuario usuario)
        {
            await _usuarioRepositorio.Insert(usuario);
        }
    }
}
