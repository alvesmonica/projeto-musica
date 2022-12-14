using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMusica.Data;
using ProjetoMusica.Models;

namespace ProjetoMusica.Pages.Musicas
{
    public class EditModel : PageModel
    {
        private readonly ProjetoMusica.Data.ProjetoMusicaContext _context;

        public EditModel(ProjetoMusica.Data.ProjetoMusicaContext context)
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

            var musica =  await _context.Musica.FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null)
            {
                return NotFound();
            }
            Musica = musica;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Musica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaExists(Musica.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MusicaExists(int id)
        {
          return (_context.Musica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
