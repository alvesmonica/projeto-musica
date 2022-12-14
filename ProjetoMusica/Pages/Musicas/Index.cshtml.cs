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
    public class IndexModel : PageModel
    {
        private readonly ProjetoMusica.Data.ProjetoMusicaContext _context;

        public IndexModel(ProjetoMusica.Data.ProjetoMusicaContext context)
        {
            _context = context;
        }

        public IList<Musica> Musica { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Musica != null)
            {
                Musica = await _context.Musica.ToListAsync();
            }
        }
    }
}
