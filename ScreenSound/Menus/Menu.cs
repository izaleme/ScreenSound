using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public virtual void Executar(DAL<Artista> artistaDAL)
    {
        LimparConsole();
    }

    public virtual void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        LimparConsole();
    }

    private void LimparConsole()
    {
        Console.Clear();
    }
}
