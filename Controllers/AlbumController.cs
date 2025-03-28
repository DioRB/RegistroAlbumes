using Microsoft.AspNetCore.Mvc;
using RegistroAlbumes.Models;
using RegistroAlbumes.Data;
using Microsoft.EntityFrameworkCore;

namespace RegistroAlbumes.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public AlbumController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Album> lista = await _appDbContext.Albumes.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Album album)
        {
            await _appDbContext.Albumes.AddAsync(album); 
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof (Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Album album = await _appDbContext.Albumes.FirstAsync(e => e.IdAlbum == id);
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Album album)
        {
            _appDbContext.Albumes.Update(album);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Album album = await _appDbContext.Albumes.FirstAsync(e => e.IdAlbum == id);

            _appDbContext.Albumes.Remove(album);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));

        }
    }
}
