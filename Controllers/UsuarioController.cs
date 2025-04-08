using Alugai.Data;
using Alugai.Models;
using Alugai.Models.Services;
using Alugai.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Alugai.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _service;


        public UsuarioController(ApplicationDbContext context)
        {
            _service = new UsuarioService(context);
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var todosUsuarios = _service.ListarTodos();

            return View(todosUsuarios);
        }

        [Authorize]
        public ActionResult Details()
        {
            var cpf = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value;
            var usuarioLogado = _service.PegarUsuario(cpf);

            return View(usuarioLogado);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var pwd = Criptografia.Encriptar(collection["SenhaHash"]);

                var novoUsuario = new Usuario 
                { 
                    Nome = collection["Nome"],
                    Telefone = collection["Telefone"],
                    Email = collection["Email"],
                    Cpf = collection["Cpf"],
                    SenhaHash = pwd
                };

                await _service.Criar(novoUsuario);

                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
