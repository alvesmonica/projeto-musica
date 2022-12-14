using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoMusica.Data;
using ProjetoMusica.Models;

namespace ProjetoMusica.Pages.Musicas
{
    public class DeleteModel : PageModel
    {
        private readonly ProjetoMusica.Data.ProjetoMusicaContext _context;

        public DeleteModel(ProjetoMusica.Data.ProjetoMusicaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Musica Musica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica.FirstOrDefaultAsync(m => m.Id == id);

            if (musica == null)
            {
                return NotFound();
            }
            else 
            {
                Musica = musica;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }
            var musica = await _context.Musica.FindAsync(id);

            if (musica != null)
            {
                Musica = musica;
                _context.Musica.Remove(Musica);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
