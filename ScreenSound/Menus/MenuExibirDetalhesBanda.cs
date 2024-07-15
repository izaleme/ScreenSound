using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas) // override sobrescreve o método
    {
        base.Executar(bandasRegistradas); // Executa o método pai
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");

        string nomeDaBanda = Console.ReadLine()!.ToLower();
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.WriteLine(banda.Resumo);
            Console.WriteLine($"A média da banda {nomeDaBanda} é {banda.Media}.");

            if (banda.Albuns.Count > 0)
            {
                Console.WriteLine("\nDiscografia:");

                foreach (Album album in banda.Albuns)
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
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        }

        Console.Write("\nAperte qualquer tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }
}
