using ScreenSound.Banco;
using ScreenSound.Models;
using ScreenSoundAPI.Filters;
using ScreenSoundAPI.Models;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    /*public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir detalhes do artista");

        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPeloNome(nomeDoArtista);

        if (artistaRecuperado is not null)
        {
            Console.WriteLine("\nDiscografia:");
            artistaRecuperado.ExibirDiscografia();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }*/

    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibindo todas as músicas registradas na nossa aplicação");

        List<ScreenSoundAPI.Models.Musica> musicas = new List<ScreenSoundAPI.Models.Musica>
        {
            new ScreenSoundAPI.Models.Musica
            {
                Nome = "Bohemian Rhapsody",
                Artista = "Queen",
                Duracao = 354000,
                Genero = "Rock",
                AnoString = "1975",
                Key = 9
            },
            new ScreenSoundAPI.Models.Musica
            {
                Nome = "Shape of You",
                Artista = "Ed Sheeran",
                Duracao = 263000,
                Genero = "Pop",
                AnoString = "2017",
                Key = 6
            },
            new ScreenSoundAPI.Models.Musica
            {
                Nome = "Hotel California",
                Artista = "Eagles",
                Duracao = 390000,
                Genero = "Rock",
                AnoString = "1976",
                Key = 0
            },
            new ScreenSoundAPI.Models.Musica
            {
                Nome = "Smells Like Teen Spirit",
                Artista = "Nirvana",
                Duracao = 301000,
                Genero = "Grunge",
                AnoString = "1991",
                Key = 7
            },
            new ScreenSoundAPI.Models.Musica
            {
                Nome = "Blinding Lights",
                Artista = "The Weeknd",
                Duracao = 200000,
                Genero = "Synthpop",
                AnoString = "2019",
                Key = 10
            }
        };

        LinqOrder csLinq = new LinqOrder();
        LinqOrder.ExibirArtistasOrdenados(musicas);

        Console.Write("\nAperte qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
    }
}
