using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarEpisodio : Menu
{
    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Registro de Episódios");

        Console.Write("Digite o nome do episódio que deseja registrar: ");
        string nomeEpisodio = Console.ReadLine()!;

        Console.Write("Digite a ordem do episódio informado: ");
        if (!int.TryParse(Console.ReadLine()!, out int ordemEpisodio))
        {
            Console.WriteLine("Opção inválida!");
            Console.WriteLine("Retornando ao menu principal...");
            Thread.Sleep(1000);
            Console.Clear();
            return;
        }

        Console.Write("Digite a duração do episódio informado: ");
        int duracaoEpisodio = int.Parse(Console.ReadLine()!);

        Episodio newEpisodio = new Episodio(ordemEpisodio, nomeEpisodio, duracaoEpisodio);
        Console.WriteLine("\nEpisódio registrado com sucesso!!");

        Console.WriteLine("Deseja adicionar convidados ao episódio? (1 = SIM, 2 = NÃO)");
        string addConvidados = Console.ReadLine()!;

        if (int.TryParse(addConvidados, out int result))
        {
            if (result == 1)
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

                    convidado = Console.ReadLine()!; // Atualiza a variável convidado
                }
            }
        }
        else
        {
            Console.WriteLine("Opção inválida!");
        }

        Console.WriteLine("Retornando ao menu principal...");
        Thread.Sleep(1000);
        Console.Clear();
    }
}
