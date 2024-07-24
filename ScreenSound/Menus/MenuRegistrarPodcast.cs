using ScreenSound.Models;
using System.Text.RegularExpressions;

namespace ScreenSound.Menus;

internal class MenuRegistrarPodcast : Menu
{
    public override void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        base.Executar(podcastsRegistrados);
        ExibirTituloDaOpcao("Registro de Podcasts");

        while (true)
        {
            Console.Write("Digite o nome do podcast que deseja registrar: ");
            string nomePodcast = Console.ReadLine()!;

            Console.Write("Digite o host do podcast informado: ");
            string hostPodcast = Console.ReadLine()!;

            if (!podcastsRegistrados.ContainsKey(nomePodcast))
            {
                Podcast newPodcast = new Podcast(hostPodcast, nomePodcast);
                podcastsRegistrados.Add(nomePodcast, newPodcast);
                Console.WriteLine("Podcast registrado com sucesso!");

                Console.Write("\nDeseja adicionar episódios ao podcast? ");
                string answer = Console.ReadLine()!;

                if (Regex.IsMatch(answer.ToLower(), @"^(1|sim|s|ss|yes|ye)$"))
                {
                    Console.WriteLine();
                    new MenuRegistrarEpisodio(newPodcast, podcastsRegistrados);
                    break;
                }
                else
                {
                    Console.Write("\nAperte qualquer tecla para voltar ao menu principal ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            else
            {
                Console.WriteLine("Já existe um podcast registrado com esse nome! Tente novamente.\n");
            }
        }
    }
}
