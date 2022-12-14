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
    public class DetailsModel : PageModel
    {
        private readonly ProjetoMusica.Data.ProjetoMusicaContext _context;

        public DetailsModel(ProjetoMusica.Data.ProjetoMusicaContext context)
        {
            _context = context;
        }

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
    }
}
