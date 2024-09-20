using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibindo todos os artistas/bandas registrados na nossa aplicação");

        try
        {
            var artistas = artistaDAL.Listar() ?? Enumerable.Empty<Artista>();
            foreach (var artista in artistas)
            {
                Console.WriteLine($"Artista: {artista}");
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"\n[ERRO] \nOcorreu um erro! Contate o suporte! \n{ex.Message}");
            //Console.ReadKey();
            //Environment.Exit(0);
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
