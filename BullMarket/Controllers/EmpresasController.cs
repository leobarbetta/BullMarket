using BullMarket.Web.Models;
using BullMarket.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BullMarket.Web.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly BullMarketContext _context;

        public EmpresasController(BullMarketContext context) => _context = context;

        public IActionResult Index() => View();

        public IActionResult CarregaCreate() => PartialView("_Create");

        [HttpPost]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (!ModelState.IsValid)
                return Json(new { Mensagem = "Formuario invalido" });

            _context.Add(empresa);
            await _context.SaveChangesAsync();

            return Json(new { Mensagem = "Sucesso" });
        }

        public async Task<IActionResult> CarregaUpdate(int? id)
        {
            if (id == null)
                return Json(new { Mensagem = "Falha" });

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                return Json(new { Mensagem = "Falha" });

            return PartialView("_Update", empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Empresa empresa)
        {
            if (id != empresa.Id)
                return Json(new { Mensagem = "Falha" });

            if (!ModelState.IsValid)
                return Json(new { Mensagem = "Formulario invalido" });

            _context.Update(empresa);
            await _context.SaveChangesAsync();

            return Json(new { Mensagem = "Sucesso" });
        }

        public async Task<IActionResult> Lista() => PartialView("_Lista", await _context.Empresas.ToListAsync());
    }
}
