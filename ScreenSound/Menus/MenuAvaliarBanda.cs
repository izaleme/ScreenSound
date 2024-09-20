using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Avaliar Artista/Banda");

        Console.Write("Digite o nome do artista ou banda que deseja avaliar: ");

        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPeloNome(nomeDoArtista);

        if (artistaRecuperado is not null)
        {
            Console.Write($"Qual a nota que o artista {artistaRecuperado} merece: ");
            Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
            artistaRecuperado.AdicionarNota(nota);
            Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o artista {artistaRecuperado}.");
            Thread.Sleep(1850);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {artistaRecuperado} não foi encontrado!");
            Console.Write("Retornando ao menu principal... ");
            Thread.Sleep(2200);
            Console.Clear();
        }
    }
}
