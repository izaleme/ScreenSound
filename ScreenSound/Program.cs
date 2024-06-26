﻿using ScreenSound.Menus;
using ScreenSound.Models;
using OpenAI_API;

Banda wallows = new Banda("Wallows");
wallows.AdicionarNota(new Avaliacao(10));
wallows.AdicionarNota(new Avaliacao(8));
wallows.AdicionarNota(new Avaliacao(6));
Banda tameImpala = new Banda("Tame Impala");

// TESTE ------------------------------------------------------------------------------------------------
//var client = new OpenAIAPI(""); // Chave do chat gpt
//var chat = client.Chat.CreateConversation();
//chat.AppendSystemMessage("Resuma a banda Wallows em 1 parágrafo, adotando um estilo informal.");

//try
//{
//    var resposta = await chat.GetResponseFromChatbotAsync(); // Await espera o término da ação para continuar
//    Console.WriteLine(resposta);
//}
//catch (Exception err)
//{
//    Console.WriteLine("Ocorreu um erro:");
//    Console.WriteLine("----------------");
//    Console.WriteLine(err.Message);
//}
// ------------------------------------------------------------------------------------------------------

// StringComparer.OrdinalIgnoreCase: Permite que o usuário encontre a banda sem problemas de letras maiúsculas ou minúsculas
Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>(StringComparer.OrdinalIgnoreCase)
{
    { wallows.Nome, wallows },
    { tameImpala.Nome, tameImpala }
};

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarBanda());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuMostrarBandas());
opcoes.Add(4, new MenuAvaliarBanda());
opcoes.Add(5, new MenuAvaliarAlbum());
opcoes.Add(6, new MenuExibirDetalhes());
opcoes.Add(-1, new MenuSair());

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
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    if (!int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
    {
        Console.WriteLine("Opção inválida. O programa será encerrado.");
        return;
    }

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuExibicao = opcoes[opcaoEscolhidaNumerica];
        menuExibicao.Executar(bandasRegistradas);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();