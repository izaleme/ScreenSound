using ScreenSound.Models;

namespace ScreenSound.Test
{
    public class MusicaConstrutor
    {
        [Theory]
        [InlineData("Are You Bored Yet?", "Wallows")]
        [InlineData("What You Know", "Two Door Cinema Club")]
        [InlineData("Brazil", "Declan McKenna")]
        public void CadastraMscCorretamenteComDadosEntrada(string nomeMusica, string nomeBanda)
        {
            // Arrange
            Banda banda = new Banda(nomeBanda);

            // Act
            Musica musica = new Musica(banda, nomeMusica);

            // Assert
            Assert.Equal(nomeMusica, musica.Nome);
        }

        [Theory]
        [InlineData("Are You Bored Yet?", "Wallows")]
        [InlineData("What You Know", "Two Door Cinema Club")]
        [InlineData("Home", "Edward Shape")]
        public void RetornaDescricaoResumidaCorretamenteAoCadastrarMsc(string nomeMusica, string nomeBanda)
        {
            // Arrange
            Banda banda = new Banda(nomeBanda);
            Musica musica = new Musica(banda, nomeMusica);
            string retornoEsperado = $"A música {musica.Nome} pertence à banda {musica.Artista}";

            // Act
            string retorno = musica.DescricaoResumida;

            // Assert
            Assert.Equal(retornoEsperado, retorno);
        }

        [Theory]
        [InlineData("What Once Was", "Her's", 160, true)]
        [InlineData("A Horse With No Name", "America", 300, false)]
        public void RetornaFichaTecnicaComDadosEntrada(string nomeMusica, string nomeBanda, int duracaoMsc, bool disponivel)
        {
            // Arrange
            Banda banda = new Banda(nomeBanda);
            Musica musica = new Musica(banda, nomeMusica);
            musica.Duracao = duracaoMsc;
            musica.Disponivel = disponivel;

            string expectedOutput = $"Nome: {musica.Nome}\r\n" +
                                    $"Artista: {banda.Nome}\r\n" +
                                    $"Duração: {musica.Duracao}\r\n";

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
}