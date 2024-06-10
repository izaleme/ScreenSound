using ScreenSound.Menus;
using ScreenSound.Models;

Banda wallows = new Banda("Wallows");
wallows.AdicionarNota(new Avaliacao(10));
wallows.AdicionarNota(new Avaliacao(8));
wallows.AdicionarNota(new Avaliacao(6));
Banda tameImpala = new Banda("Tame Impala");

// StringComparer.OrdinalIgnoreCase: Permite que o usuário encontre a banda sem problemas de letras maiúsculas ou minúsculas
Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>(StringComparer.OrdinalIgnoreCase)
{
    { wallows.Nome, wallows },
    { tameImpala.Nome, tameImpala }
};

void ExibirLogo()
{
    Console.WriteLine(@"

    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    if (!int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
    {
        Console.WriteLine("Opção inválida. O programa será encerrado.");
        return;
    }

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            MenuRegistrarBanda menu1 = new();
            menu1.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 2:
            MenuRegistrarAlbum menu2 = new();
            menu2.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 3:
            MenuMostrarBandasRegistradas menu3 = new();
            menu3.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 4:
            MenuAvaliarBanda menu4 = new();
            menu4.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case 5:
            MenuExibirDetalhes menu5 = new MenuExibirDetalhes();
            menu5.Executar(bandasRegistradas);
            ExibirOpcoesDoMenu();
            break;
        case -1:
            Console.WriteLine("Tchau tchau! :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

ExibirOpcoesDoMenu();