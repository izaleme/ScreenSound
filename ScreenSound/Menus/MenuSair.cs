using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        FecharConsole();
    }

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        FecharConsole();
    }

    private void FecharConsole()
    {
        Console.WriteLine("Tchau tchau! :)");
        Thread.Sleep(2000);
        Environment.Exit(0); // Fecha a janela de console
    }
}
