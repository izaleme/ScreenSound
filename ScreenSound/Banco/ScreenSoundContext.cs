using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.Models;
using System.Diagnostics.Metrics;

namespace ScreenSound.Banco;

public class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }

    public DbSet<Musica> Musicas { get; set; }

    public DbSet<Album> Albumns { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Genero>().HasNoKey();
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasMany(m => m.Generos)
            .WithMany()
            .UsingEntity<MusicaGenero>(
                j => j
                    .HasOne(mg => mg.Genero)
                    .WithMany(g => g.Musicas)
                    .HasForeignKey(mg => mg.GeneroId),
                j => j
                    .HasOne(mg => mg.Musica)
                    .WithMany(m => m.Generos)
                    .HasForeignKey(mg => mg.MusicaId),
                j => j
                    .HasKey(mg => new { mg.MusicaId, mg.GeneroId })
            );
    }
}
