using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMusica.Models;

namespace ProjetoMusica.Data
{
    public class ProjetoMusicaContext : DbContext
    {
        public ProjetoMusicaContext (DbContextOptions<ProjetoMusicaContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoMusica.Models.Musica> Musica { get; set; } = default!;
    }
}
