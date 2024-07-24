using ScreenSound.Models;
using System.Text.RegularExpressions;

namespace ScreenSound.Menus;

internal class MenuRegistrarEpisodio : Menu
{
    #region Attributes/Properties

    private bool adicionaPodcast = false;

    private Podcast podcast { get; }


    #endregion

    #region Builders

    public MenuRegistrarEpisodio()
    {
        adicionaPodcast = false;
    }

    public MenuRegistrarEpisodio(Podcast podcastt, Dictionary<string, Podcast> podcastsRegistrados)
    {
        adicionaPodcast = true;
        podcast = podcastt;
        Executar(podcastsRegistrados);
    }

    #endregion

    #region Methods

    public override void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        if (!adicionaPodcast)
        {
            base.Executar(podcastsRegistrados);
            ExibirTituloDaOpcao("Registro de Episódios");
        }

        Console.Write("Digite o nome do episódio que deseja registrar: ");
        string nomeEpisodio = Console.ReadLine()!;

        Console.Write("Digite a ordem do episódio informado: ");
        if (!int.TryParse(Console.ReadLine()!, out int ordemEpisodio))
        {
            Console.WriteLine("Opção inválida!");
            Console.WriteLine("Retornando ao menu principal...");
            Thread.Sleep(1500);
            Console.Clear();
            return;
        }

        Console.Write("Digite a duração do episódio informado: ");
        int duracaoEpisodio = int.Parse(Console.ReadLine()!);

        Episodio newEpisodio = new Episodio(ordemEpisodio, nomeEpisodio, duracaoEpisodio);
        Console.WriteLine("\nEpisódio registrado com sucesso!!");

        if (adicionaPodcast)
        {
            podcast.AdicionarEpisodio(newEpisodio);
        }

        Console.Write("\nDeseja adicionar convidados ao episódio? ");
        string addConvidados = Console.ReadLine()!;

        if (Regex.IsMatch(addConvidados.ToLower(), @"^(1|sim|s|ss|yes)$"))
        {
            const string num = "-1";
            Console.Write("Digite o nome do convidado ou -1 para sair: ");
            string convidado = Console.ReadLine()!;

            while (convidado != num)
            {
                if (int.TryParse(convidado, out int numConvidado))
                {
                    Console.Write("O convidado é um número. Digite um nome válido: ");
                }
                else
                {
                    newEpisodio.AdicionarConvidados(convidado);
                    Console.WriteLine("\nConvidado adicionado com sucesso!");
                    Console.Write("Digite outro nome de convidado ou -1 para sair: ");
                }

                convidado = Console.ReadLine()!; // Atualiza a variável 'convidado'
            }
        }

        if (!adicionaPodcast)
        {
            Console.Write("\nDigite o nome do podcast ao qual você vai adicionar: ");
            string nomePodcast = Console.ReadLine()!;

            if (podcastsRegistrados.ContainsKey(nomePodcast))
            {
                Podcast podcast = podcastsRegistrados[nomePodcast.Trim()]; // Recupera o objeto Podcast do dicionário
                podcast.AdicionarEpisodio(newEpisodio); // Adiciona o episódio ao podcast
            }
            else
            {
                Console.WriteLine("Podcast não encontrado!");
            }
        }

        Console.WriteLine("Retornando ao menu principal...");
        Thread.Sleep(2200);
        Console.Clear();
    }

    #endregion
}
