using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.Controllers
{
    [Authorize]
    public class ArtistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index(string buscar, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;

            IQueryable<Artista> artistasQuery = _context.Artistas;

            if (!string.IsNullOrEmpty(buscar))
            {
                artistasQuery = artistasQuery.Where(a => a.Nombre.Contains(buscar));
            }

            var artistas = await artistasQuery.ToListAsync();

            return View(artistas);
        }

        ///[Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            //ViewData["ReturnUrl"] = returnurl;

            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artistas.FirstOrDefaultAsync(a => a.ArtistasId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }
        [Authorize]

        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; // Guarda el valor de returnUrl si es necesario.
            return View(); // Retorna la vista.
        }


        ///[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Genero,Edad")] Artista artista)
        {
            //ViewData["ReturnUrl"] = returnurl;

            if (ModelState.IsValid)
            {
                _context.Add(artista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        ///[Authorize]
        public async Task<IActionResult> Update(int? id)
        {
           // ViewData["ReturnUrl"] = returnurl;

            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        ///[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ArtistasId,Nombre,Genero,Edad")] Artista artista)
        {
            //ViewData["ReturnUrl"] = returnurl;

            if (id != artista.ArtistasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistaExists(artista.ArtistasId))
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
            return View(artista);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            ////ViewData["ReturnUrl"] = returnurl;

            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artistas.FirstOrDefaultAsync(a => a.ArtistasId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            //ViewData["ReturnUrl"] = returnurl;

            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artistas.Any(e => e.ArtistasId == id);
        }
    }

}
