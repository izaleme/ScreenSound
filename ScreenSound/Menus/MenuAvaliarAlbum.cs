using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Avaliar álbum");

        Console.Write("Digite o nome do artista/banda que deseja avaliar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPeloNome(nomeDoArtista);

        if (artistaRecuperado is not null)
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (artistaRecuperado.Albuns.Any(a => a.Nome.Equals(tituloAlbum))) // Entra no if se existir um álbum com o nome digitado, na lista de álbuns
            {
                Album album = artistaRecuperado.Albuns.First(a => a.Nome.Equals(tituloAlbum)); // Pega a primeira opção
                Console.Write($"Qual a nota que o album {tituloAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o álbum {tituloAlbum}!");
                Thread.Sleep(1850);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"O álbum {tituloAlbum} não foi encontrado!");
                Console.Write("\nRetornando ao menu principal... ");
                Thread.Sleep(2200);
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"O artista {artistaRecuperado} não foi encontrado!");
            Console.Write("\nRetornando ao menu principal... ");
            Thread.Sleep(2200);
            Console.Clear();
        }
    }
}
