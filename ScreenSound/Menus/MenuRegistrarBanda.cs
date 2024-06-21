using OpenAI_API;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas); // Executa o método pai
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        //var client = new OpenAIAPI(""); // Chave do chat gpt
        //var chat = client.Chat.CreateConversation();
        //chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo, adotando um estilo informal."); // Requisição pra API
        //var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult(); // GetAwaiter().GetResult() funciona como o await e espera o término da ação para continuar
        //banda.Resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
