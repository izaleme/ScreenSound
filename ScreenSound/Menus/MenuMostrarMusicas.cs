using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    public void Executar()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibindo todas as músicas registradas na nossa aplicação");

        ScreenSoundAPI.Filters.LinqOrder csLinq = new ScreenSoundAPI.Filters.LinqOrder();
        //csLinq.ExibirMusicasOrdenadas();

        Console.Write("\nAperte qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
    }
}
