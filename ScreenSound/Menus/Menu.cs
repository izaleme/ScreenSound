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

    public virtual void Executar(Dictionary<string, Podcast> podcastsRegistrados)
    {
        Console.Clear();
    }

    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas) // virtual é um método que pode ser sobrescrito
    {
        Console.Clear();
    }
    
}
