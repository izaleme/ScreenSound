using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarPodcast : Menu
{
    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Registro de Podcasts");

        Console.Write("Digite o nome do podcast que deseja registrar: ");
        string nomePodcast = Console.ReadLine()!;

        Console.Write("Digite o host do podcast informado: ");
        string hostPodcast = Console.ReadLine()!;

        Podcast newPodcast = new Podcast(hostPodcast, nomePodcast);
        Console.WriteLine("\nPodcast registrado com sucesso!");

        // Aqui posso criar depois uma opção para adicionar episodios ao podcast se o usuario quiser

        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
