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

        [Theory]
        [InlineData("ABBA", "Test Song 1", null)]
        [InlineData("Wallows", "Test Song 2", -1)]
        [InlineData("Red Hot Chili Peppers", "Test Song 3", 0)]
        public void RetornaAnoDeLancamentoNuloQuandoValorEhMenorQueZero(string nomeBanda, string nomeMusica, int? anoInvalido)
        {
            // Arrange
            Banda banda = new Banda(nomeBanda);
            Musica musica = new Musica(banda, nomeMusica);

            // Act
            musica.AnoLancamento = anoInvalido;

            // Assert
            Assert.Null(musica.AnoLancamento);
        }

        [Fact]
        public void RetornaLancamentoQuandoDadosValidos()
        {
            // Arrange
            int anoLancam = 2024;
            Banda banda = new Banda("Billie Eilish");
            Musica musica = new Musica(banda, "Chihiro");

            // Act
            musica.AnoLancamento = anoLancam;

            // Assert
            Assert.Equal(anoLancam, musica.AnoLancamento);
        }
    }
}