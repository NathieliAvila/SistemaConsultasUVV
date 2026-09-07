using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SistemaConsultasUVV.Data;
using SistemaConsultasUVV.Models;
using SistemaConsultasUVV.Models.ViewModels;

namespace SistemaConsultasUVV.Controllers
{
    [Authorize] 
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        //Pega o Id do usuário logado a partir dos cookies
        private int UsuarioLogadoId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        //GET: /Consultas
        public async Task<IActionResult> Index()
        {
            var minhasConsultas = await _context.Consultas.Where(c => c.UsuarioId == UsuarioLogadoId)
                .OrderBy(c => c.DataHora)
                .ToListAsync();

            return View(minhasConsultas);
        }

        //GET: /Consultas/Criar
        public IActionResult Criar()
        {
            return View();
        }

        //POST: /Consultas/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ConsultaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var consulta = new Consulta
            {
                Especialidade = model.Especialidade,
                DataHora = model.DataHora,
                Descricao = model.Descricao,
                UsuarioId = UsuarioLogadoId
            };

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET: /Consultas/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            //Verificação de isolamento
            if (consulta.UsuarioId != UsuarioLogadoId)
            {
                return Forbid();
            }

            var model = new ConsultaViewModel
            {
                Id = consulta.Id,
                Especialidade = consulta.Especialidade,
                DataHora = consulta.DataHora,
                Descricao = consulta.Descricao
            };

            return View(model);
        }
        // POST: /Consultas/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, ConsultaViewModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var consulta = await _context.Consultas.FindAsync(id);

            if(consulta == null)
            {
                return NotFound();
            }

            if (consulta.UsuarioId != UsuarioLogadoId)
            {
                return Forbid();
            }

            consulta.Especialidade = model.Especialidade;
            consulta.DataHora = model.DataHora;
            consulta.Descricao = model.Descricao;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET: /Consultas/Excluir/5
        public async Task<IActionResult> Excluir(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            if (consulta.UsuarioId != UsuarioLogadoId)
            {
                return Forbid();
            }

            return View(consulta);
        }

        // POST: /Consultas/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmado(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            if (consulta.UsuarioId != UsuarioLogadoId)
            {
                return Forbid();
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
