using Alugai.Models;
using Alugai.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alugai.Controllers
{
    [Authorize]
    public class ImovelController : Controller
    {
        private readonly ImovelService _imovelService;

        public ImovelController(ImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        // GET: ImovelController
        public ActionResult Index()
        {
            var cpf = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value;
            var imoveis = _imovelService.ListarImoveis(cpf);

            return View(imoveis);
        }

        // GET: ImovelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImovelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Imovel novoImovel)
        {
            try
            {
                novoImovel.AnuncianteCpf = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value;

                await _imovelService.CriarImovel(novoImovel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImovelController/Edit/5
        public ActionResult Edit(int id)
        {
            var cpf = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value;
            var imovel = _imovelService.BuscarImovel(id);

            return View(imovel);
        }

        // POST: ImovelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Imovel imovel)
        {
            try
            {
                await _imovelService.AtualizarImovel(imovel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> CancelarAnuncio(int id)
        {
            try
            {
                await _imovelService.MudarStatusAnuncioImovel(id, false);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Anunciar(int id)
        {
            try
            {
                await _imovelService.MudarStatusAnuncioImovel(id, true);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ImovelController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _imovelService.RemoverImovel(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
