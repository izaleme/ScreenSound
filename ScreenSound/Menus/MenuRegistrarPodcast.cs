using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarPodcast : Menu
{
    public override void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        base.Executar(podcastsRegistrados);
        ExibirTituloDaOpcao("Registro de Podcasts");

        Console.Write("Digite o nome do podcast que deseja registrar: ");
        string nomePodcast = Console.ReadLine()!;

        Console.Write("Digite o host do podcast informado: ");
        string hostPodcast = Console.ReadLine()!;

        Podcast newPodcast = new Podcast(hostPodcast, nomePodcast);
        podcastsRegistrados.Add(nomePodcast, newPodcast);
        Console.WriteLine("\nPodcast registrado com sucesso!");

        Console.Write("\nDeseja adicionar episódios ao podcast? ");
        string answer = Console.ReadLine()!;

        if (answer == "1" || answer.ToLower() == "sim" || answer.ToLower() == "s" || answer.ToLower() == "ss")
        {
            Console.WriteLine();
            new MenuRegistrarEpisodio(newPodcast, podcastsRegistrados);
        }
        else
        {
            Console.Write("Aperte qualquer tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
