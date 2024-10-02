using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //Agregamos los diferentes modelos que necesitamos
        //
        public DbSet<AppUsuario> AppUsuario { get; set; }

        public DbSet<Artista> Artistas { get; set; } // DbSet para la tabla de artistas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama al método base para aplicar las configuraciones predeterminadas de Identity
            base.OnModelCreating(modelBuilder);

            // Configuración específica para la entidad Artista
            modelBuilder.Entity<Artista>()
                .HasKey(a => a.ArtistasId); // Define ArtistasId como la clave primaria


        }


    }
}
