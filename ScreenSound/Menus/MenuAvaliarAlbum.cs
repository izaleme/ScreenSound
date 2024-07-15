using ScreenSound.Models;
namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);

        ExibirTituloDaOpcao("Avaliar álbum");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum))) // Entra no if se existir um álbum com o nome digitado, na lista de álbuns
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum)); // Pega a primeira opção
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
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.Write("\nRetornando ao menu principal... ");
            Thread.Sleep(2200);
            Console.Clear();
        }
    }
}
