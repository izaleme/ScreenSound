using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesPodcast : Menu
{
    public override void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        base.Executar(podcastsRegistrados); // Executa o método pai
        ExibirTituloDaOpcao("Exibir detalhes do Podcast");

        Console.WriteLine("Podcasts registrados:");
        foreach (string pod in podcastsRegistrados.Keys)
        {
            Console.WriteLine($"--> {pod}");
        }

        bool loop = true;
        while (loop)
        {
            Console.Write("\nDigite o nome do podcast que você deseja exibir: ");
            string nomePodcast = Console.ReadLine()!.ToLower();
            if (podcastsRegistrados.ContainsKey(nomePodcast))
            {
                loop = false;
                Podcast podcast = podcastsRegistrados[nomePodcast];
                podcast.ExibirDetalhes());
            }
            else
            {
                if (nomePodcast == "-1")
                {
                    loop = false;

                    Console.Write("\nRetornando ao menu principal... ");
                    Thread.Sleep(2200);
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine($"O Podcast {nomePodcast} não foi encontrado!");
                    Console.WriteLine("Tente novamente ou digite -1 para voltar ao menu principal.");
                }
            }
        }

        Console.Write("Aperte qualquer tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }
}