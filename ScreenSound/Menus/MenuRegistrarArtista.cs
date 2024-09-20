using OpenAI_API;
using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista/banda que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        Console.Write("Digite a bio do artista que deseja registrar: ");
        //var client = new OpenAIAPI(""); // Chave do chat gpt
        //var chat = client.Chat.CreateConversation();
        //chat.AppendSystemMessage($"Resuma o artista {nomeDoArtista} em 1 parágrafo, adotando um estilo informal."); // Requisição pra API
        //var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult(); // GetAwaiter().GetResult() funciona como o await e espera o término da ação para continuar
        //string bioDoArtista = resposta.ToString();
        string bioDoArtista = Console.ReadLine()!;

        Artista artista = new Artista(nomeDoArtista, bioDoArtista);
        artistaDAL.Adicionar(artista);

        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}