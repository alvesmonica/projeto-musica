using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMusica.Data;
using ProjetoMusica.Models;

namespace ProjetoMusica.Pages.Musicas
{
    public class CreateModel : PageModel
    {
        private readonly ProjetoMusica.Data.ProjetoMusicaContext _context;

        public CreateModel(ProjetoMusica.Data.ProjetoMusicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Musica Musica { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Musica == null || Musica == null)
            {
                return Page();
            }

            _context.Musica.Add(Musica);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
