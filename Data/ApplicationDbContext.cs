using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial.Models;

namespace Parcial.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Equipo> DbSetEquipo { get; set; }
    public DbSet<Asociacion> DbSetAsociacion { get; set; }
    public DbSet<Jugador> DbSetJugador { get; set; }


   
}

