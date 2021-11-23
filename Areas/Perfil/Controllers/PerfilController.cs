using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Worki.Data;
using Worki.Data.Models;

namespace Worki.Areas.Perfil.Controllers
{
    [Area("Perfil")]
    public class PerfilController : Controller
    {
        private readonly WorkiContext _context;
        private readonly Service.IUsuarioService _usuarioService;

        public PerfilController(WorkiContext context, Service.IUsuarioService usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        // GET: Perfil/Perfil
        public async Task<IActionResult> Index()
        {
            var data = await _context.PerPerfils.Include(
                x => x.CpeConfiguracionesPerfils
            ).ThenInclude(
                x => x.Con
            ).Include(
                x => x.Gups
            ).Include(
                x => x.Hobs
            ).FirstAsync(
                x => x.PerId == _usuarioService.GetID()
            );

            var workiContext = _context.PerPerfils.Include(p => p.Usu);
            return View(await workiContext.ToListAsync());
        }

        // GET: Perfil/Perfil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perPerfil = await _context.PerPerfils
                .Include(p => p.Usu)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (perPerfil == null)
            {
                return NotFound();
            }

            return View(perPerfil);
        }

        // GET: Perfil/Perfil/Create
        public IActionResult Create()
        {
            ViewData["UsuId"] = new SelectList(_context.UsuUsuarios, "UsuId", "UsuCorreo");
            return View();
        }

        // POST: Perfil/Perfil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerId,PerImagen,PerCargo,PerEstado,UsuId")] PerPerfil perPerfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perPerfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuId"] = new SelectList(_context.UsuUsuarios, "UsuId", "UsuCorreo", perPerfil.UsuId);
            return View(perPerfil);
        }

        // GET: Perfil/Perfil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perPerfil = await _context.PerPerfils.FindAsync(id);
            if (perPerfil == null)
            {
                return NotFound();
            }
            ViewData["UsuId"] = new SelectList(_context.UsuUsuarios, "UsuId", "UsuCorreo", perPerfil.UsuId);
            return View(perPerfil);
        }

        // POST: Perfil/Perfil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerId,PerImagen,PerCargo,PerEstado,UsuId")] PerPerfil perPerfil)
        {
            if (id != perPerfil.PerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perPerfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerPerfilExists(perPerfil.PerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuId"] = new SelectList(_context.UsuUsuarios, "UsuId", "UsuCorreo", perPerfil.UsuId);
            return View(perPerfil);
        }

        // GET: Perfil/Perfil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perPerfil = await _context.PerPerfils
                .Include(p => p.Usu)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (perPerfil == null)
            {
                return NotFound();
            }

            return View(perPerfil);
        }

        // POST: Perfil/Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perPerfil = await _context.PerPerfils.FindAsync(id);
            _context.PerPerfils.Remove(perPerfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerPerfilExists(int id)
        {
            return _context.PerPerfils.Any(e => e.PerId == id);
        }
    }
}
