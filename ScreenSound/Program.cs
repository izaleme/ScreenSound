﻿using ScreenSound.Menus;
using ScreenSound.Models;
using OpenAI_API;
using ScreenSound.Banco;

try
{
    var artistaDAL = new ArtistaDAL();
    artistaDAL.Adicionar(new Artista("Yaelokre", "Yaelokre is a storytelling project run by Keath Ósk, honouring wonderment through song and illustration, portraying an ensemble of four young minstrels known as \"The Lark\"."));

    var listaArtistas = artistaDAL.Listar();
    
    foreach (var artista in listaArtistas)
    {
        Console.WriteLine(artista);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
return;

//MenuMostrarMusicas teste = new MenuMostrarMusicas();
//teste.Executar();
//return;

// Adicionando dados de base Bandas
Banda wallows = new Banda("Wallows");
wallows.AdicionarNota(new Avaliacao(10));
wallows.AdicionarNota(new Avaliacao(8));
wallows.AdicionarNota(new Avaliacao(6));
Banda tameImpala = new Banda("Tame Impala");

// Adicionando dados de base Podcasts
Episodio ep1 = new Episodio(1, "Radio Silêncio", 25);
ep1.AdicionarConvidados("Ash");

Episodio ep2 = new Episodio(1, "Galdino Pataxó", 82);
ep2.AdicionarConvidados("Spotify");
ep2.AdicionarConvidados("Pataxó");

Episodio ep3 = new Episodio(2, "Caso Pesseghini", 91);
ep3.AdicionarConvidados("Steh Ferreira");

Podcast podcast1 = new Podcast("UniverseCity", "Aled");
podcast1.AdicionarEpisodio(ep1);

Podcast podcast2 = new Podcast("Café com Crime", "Dona Café");
podcast2.AdicionarEpisodio(ep2);
podcast2.AdicionarEpisodio(ep3);


/* //TESTE ------------------------------------------------------------------------------------------------
var client = new OpenAIAPI(""); // Chave do chat gpt
var chat = client.Chat.CreateConversation();
chat.AppendSystemMessage("Resuma a banda Wallows em 1 parágrafo, adotando um estilo informal.");

try
{
    var resposta = await chat.GetResponseFromChatbotAsync(); // Await espera o término da ação para continuar
    Console.WriteLine(resposta);
}
catch (Exception err)
{
    Console.WriteLine("Ocorreu um erro:");
    Console.WriteLine("----------------");
    Console.WriteLine(err.Message);
}
// ------------------------------------------------------------------------------------------------------ */

// StringComparer.OrdinalIgnoreCase: Permite que o usuário encontre a banda sem problemas de letras maiúsculas ou minúsculas
Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>(StringComparer.OrdinalIgnoreCase)
{
    { wallows.Nome, wallows },
    { tameImpala.Nome, tameImpala }
};

Dictionary<string, Podcast> podcastsRegistrados = new Dictionary<string, Podcast>(StringComparer.OrdinalIgnoreCase)
{
    { podcast1.Nome, podcast1 },
    { podcast2.Nome, podcast2 }
};

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuMostrarMusicas());
opcoes.Add(2, new MenuMostrarBandas());
opcoes.Add(3, new MenuRegistrarBanda());
opcoes.Add(4, new MenuRegistrarAlbum());
opcoes.Add(5, new MenuAvaliarBanda());
opcoes.Add(6, new MenuAvaliarAlbum());
opcoes.Add(7, new MenuExibirDetalhesBanda());
opcoes.Add(8, new MenuRegistrarPodcast());
opcoes.Add(9, new MenuRegistrarEpisodio());
opcoes.Add(10, new MenuExibirDetalhesPodcast());
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
    Console.WriteLine("Boas vindas ao Screen Sound!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para exibir todas as músicas");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para registrar uma banda");
    Console.WriteLine("Digite 4 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 5 para avaliar uma banda");
    Console.WriteLine("Digite 6 para avaliar um álbum");
    Console.WriteLine("Digite 7 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite 8 para registrar um podcast");
    Console.WriteLine("Digite 9 para registrar um episódio");
    Console.WriteLine("Digite 10 para exibir detalhes de um podcast");
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

        if (opcaoEscolhidaNumerica == 7 || opcaoEscolhidaNumerica == 8 || opcaoEscolhidaNumerica == 9)
        {
            menuExibicao.Executar(podcastsRegistrados);
        }
        else
        {
            menuExibicao.Executar(bandasRegistradas);
        }

        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();