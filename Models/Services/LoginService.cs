using Alugai.Data;
using Alugai.Models.Repositories;
using Alugai.Models.ViewModel;
using Alugai.Utils;

namespace Alugai.Models.Services
{
    public class LoginService
    {
        private readonly Repository<Usuario> usuarioRepo;

        public LoginService(ApplicationDbContext context)
        {
            usuarioRepo = new Repository<Usuario>(context);
        }

        public bool LoginValido(LoginViewModel loginViewModel)
        {
            var cpf = LimparInjecao(loginViewModel.Cpf);
            if (!usuarioRepo.Exists(x => x.Cpf == cpf))
                return false;

            var usuario = usuarioRepo.Get(x => x.Cpf == cpf).SingleOrDefault();

            var pwd = LimparInjecao(loginViewModel.Senha);
            if (usuario == null || !usuario.SenhaHash.Equals(Criptografia.Encriptar(pwd)))
                return false;

            return true;
        }

        public string LimparInjecao(string login)
        {
            login = login.Replace("\"", string.Empty);
            login = login.Replace("'", string.Empty);
            login = login.Replace("´", string.Empty);
            login = login.Replace("`", string.Empty);
            login = login.Replace(";", string.Empty);
            login = login.Replace("--", string.Empty);
            login = login.Replace("/", string.Empty);
            login = login.Replace(" ", string.Empty);
            login = login.Replace("||", string.Empty);
            login = login.Replace("|", string.Empty);
            login = login.Replace("&&", string.Empty);
            login = login.Replace("&", string.Empty);
            login = login.Replace("=", string.Empty);

            return login;
        }
    }
}
