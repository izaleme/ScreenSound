using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesBanda : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir detalhes do Artista/Banda");

        Console.Write("Digite o nome do artista ou banda que deseja conhecer melhor: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));
        if (artistaRecuperado is not null)
        {
            Console.WriteLine(artistaRecuperado.Resumo);
            Console.WriteLine($"A média do artista/banda {artistaRecuperado} é {artistaRecuperado.Media}.");

            if (artistaRecuperado.Albuns.Count > 0)
            {
                Console.WriteLine("\nDiscografia:");

                foreach (Album album in artistaRecuperado.Albuns)
                {
                    Console.WriteLine($"{album.Nome} -> {album.Media}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum álbum foi registrado ainda.");
            }
        }
        else
        {
            Console.WriteLine($"O artista/banda {artistaRecuperado} não foi encontrado!");
        }

        Console.Write("\nAperte qualquer tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }
}
