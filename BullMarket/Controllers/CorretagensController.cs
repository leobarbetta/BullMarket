using BullMarket.Web.Models;
using BullMarket.Web.Repository;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullMarket.Web.Controllers
{
    public class CorretagensController : Controller
    {
        private readonly BullMarketContext _context;

        public CorretagensController(BullMarketContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            HtmlWeb website = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.Default
            };

            List<Corretagem> corretagens = await _context.Corretagens.Include(c => c.Acao).Where(p => p.Status != StatusEnum.Vendido).ToListAsync();

            foreach (var item in corretagens)
            {
                HtmlDocument Doc = website.Load(item.Acao.Link);
                var valor = Doc.DocumentNode.Descendants().Where(p => p.Id == "last_last").FirstOrDefault().InnerText;

                if (!decimal.TryParse(valor, out decimal valorAtual))
                    continue;

                item.ValorAgora = valorAtual;
                await Update(item);
            }

            return View();
        }

        public async Task<IActionResult> CarregaCreate()
        {
            ViewBag.AcaoId = new SelectList(await _context.Empresas.ToListAsync(), "Id", "Codigo");
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Corretagem corretagem)
        {
            if (!ModelState.IsValid)
                return Json(new { Mensagem = "Formuario invalido" });

            _context.Add(corretagem);
            await _context.SaveChangesAsync();

            return Json(new { Mensagem = "Sucesso" });
        }

        public async Task<IActionResult> CarregaUpdate(int? id)
        {
            if (id == null)
                return Json(new { Mensagem = "Falha" });

            var corretagem = await _context.Corretagens.FindAsync(id);
            if (corretagem == null)
                return Json(new { Mensagem = "Falha" });

            return PartialView("_Update", corretagem);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Corretagem corretagem)
        {
            if (!ModelState.IsValid)
                return Json(new { Mensagem = "Formuario invalido" });

            _context.Update(corretagem);
            await _context.SaveChangesAsync();

            return Json(new { Mensagem = "Sucesso" });
        }

        public async Task<IActionResult> Lista() => PartialView("_Lista", await _context.Corretagens.Include(p => p.Acao).ToListAsync());
    }
}
