using ScreenSound.Models;

namespace ScreenSound.Test;

public class PodcastConstrutor
{
    [Theory]
    [InlineData("What Once Was", "Her's", 160, true, 2017)]
    [InlineData("A Horse With No Name", "America", 300, false, null)]
    public void RetornaFichaTecnicaComDadosEntrada(string nomeMusica, string nomeBanda, int duracaoMsc, bool disponivel, int? anoLancamento)
    {
        // Arrange
        Banda banda = new Banda(nomeBanda);
        Musica musica = new Musica(banda, nomeMusica);
        musica.Duracao = duracaoMsc;
        musica.Disponivel = disponivel;
        musica.AnoLancamento = anoLancamento;

        string expectedOutput = $"Nome: {musica.Nome}\r\n" +
                                $"Artista: {banda.Nome}\r\n" +
                                $"Duração: {musica.Duracao}\r\n";

        if (anoLancamento != null)
        {
            expectedOutput += $"Ano de Lançamento: {anoLancamento}\r\n";
        }

        expectedOutput += musica.Disponivel ? "Disponível no plano.\r\n" : "Adquira o plano Plus+\r\n";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw); // Captura o retorno

            // Act
            musica.ExibirFichaTecnica();

            // Assert
            string result = sw.ToString();
            Assert.Equal(expectedOutput, result);
        }
    }
}
