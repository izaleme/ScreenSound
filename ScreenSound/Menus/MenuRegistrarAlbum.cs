using ScreenSound.Banco;
using ScreenSound.Models;
namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL); // Executa o método pai
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite o artista/banda cujo álbum deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));

        if (artistaRecuperado is not null)
        {
            Console.Write("Digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            artistaRecuperado.AdicionarAlbum(new Album(tituloAlbum));
            Console.WriteLine($"O álbum {tituloAlbum} de {nomeDoArtista} foi registrado com sucesso!");
            Thread.Sleep(1850);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista/banda {nomeDoArtista} não foi encontrado!");
            Console.Write("Retornando ao menu principal... ");
            Thread.Sleep(2350);
            Console.Clear();
        }
    }
}
